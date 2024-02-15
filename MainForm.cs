using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

using PDFReader.Structures;
using PDFReader.CustomUserControls;
using System.Diagnostics;

namespace PDFReader
{
    public partial class MainForm : Form
    { 
        private string _filePath;

        Dictionary<string, List<string>> estimatesDictionary = new Dictionary<string, List<string>>()
            {
                {"Стр", new List<string>()},
                {"ИНН", new List<string>()},
                {"КПП", new List<string>()},
                {"Дата", new List<string>()},
                {"Цена", new List<string>()},
                {"Ссылка", new List<string>()},
                {"Поставщик", new List<string>()},
                {"Оборудование", new List<string>()}
            };

        AppParameters appParameters = new AppParameters();

        public MainForm()
        {
            InitializeComponent();

            openPdfFile.FileName = "";
        }

        private async Task PDFText(string path)
        {
            if (!File.Exists(path))
                return;

            PdfReader reader = new PdfReader(path);
            ShowDataGridItem.Enabled = false;
            ExportToExcelItem.Enabled = false;

            var ITNs = new List<string>() { "ИНН: ", "ИНН ", "I/IHH: " };
            var searchITNSParapmeters = new SearchParameters(ITNs, "ИНН", "[0-9]{10,12}", 13);
            var CRSs = new List<string>() { "КПП: ", "КПП " };
            var searchCRSParameters = new SearchParameters(CRSs, "КПП", "[0-9]{9}", 10);
            var searchDataParameters = new SearchParameters("Дата: ", "Дата", "[0-9]{2}[.][0-9]{2}[.][0-9]{4}", 10);
            var searchLinkParameters = new SearchParameters("Ссылка", @"\w*\.(?:com|ru)"); //(https?:\/\/|ftps?:\/\/|www\.)((?![.,?!;:()]*(\s|$))[^\s]){2,}\/
            var searchSuplierParameters = new SearchParameters("Поставщик", new List<string> { "(?:О{3}|ИП) \"(?:[^\"]+|[^\"/s])\"", @"ИП (?:[^\s]\w*\s\w*\s\w*|[^\s]\w*\s\w\.\s\w\.)" });
            var searchPriceParameters = new SearchParameters("Цена", new List<string> { @"(?:(\d+ |\d+)(\d+руб\.|\d+ руб\.))|((руб\.\d+|руб\. \d+)(?:\d+| \d+))", @"(?:(\d+ |\d+)(\d+₽|\d+ ₽))|((₽\d+|₽ \d+)(?:\d+| \d+))" });

            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                string currentText = PdfTextExtractor.GetTextFromPage(reader, page);

                // < < > > (АТ поле)

                currentText = ReplaceQuotationMarks(currentText);

                //Regex regex = new Regex("(?:О{3}|ИП) \"(?:[^\"]+|[^\"/s])\"");
                await Task.Run(() => SearchByTagsAsync(currentText, searchITNSParapmeters));
                await Task.Run(() => SearchByTagsAsync(currentText, searchCRSParameters));
                await Task.Run(() => SearchByTagAsync(currentText, searchDataParameters));
                await Task.Run(() => SearchRegexListAsync(currentText, searchSuplierParameters));
                await Task.Run(() => SearchRegexAsync(currentText, searchLinkParameters));
                await Task.Run(() => SearchByWords(currentText, "Оборудование"));
                await Task.Run(() => SearchRegexListAsync(currentText, searchPriceParameters)); //(?:(\d+ |\d+)(\d+руб\.|\d+ руб\.))|((руб\.\d+|руб\. \d+)(?:\d+| \d+))

                estimatesDictionary["Стр"].Add($"{page}");
                debugBox.AppendText($"{currentText}\n\nСтраница: {page}\n\n");
            }

            if (Task.WhenAll().IsCompleted)
            {
                ShowDataGridItem.Enabled = true;
                ExportToExcelItem.Enabled = true;
            }
            reader.Close();
        }


        // В этот момент начинается асинхронный ад. (13:27 29.01.2024)
        private Task SearchByTagsAsync(string currentText, SearchParameters searchParameters)
        {
            for (int i = 0; i < searchParameters.SearchOptions.Count; i++)
            {
                int locationIndex = currentText.IndexOf(searchParameters.SearchOptions[i]);
                if (locationIndex != -1)
                {
                    string searchSegment = currentText.Substring(locationIndex + searchParameters.SearchOptions[i].Length, searchParameters.SymbolsCount);
                    Regex regex = new Regex(searchParameters.RegexPattern);
                    if (regex.IsMatch(searchSegment))
                    {
                        string match = regex.Match(searchSegment).Value;
                        estimatesDictionary[searchParameters.EstimateKey].Add(match);
                        return Task.CompletedTask;
                    }
                }
            }
            estimatesDictionary[searchParameters.EstimateKey].Add("");
            return Task.CompletedTask;
        }

        private Task SearchByTagAsync(string currentText, SearchParameters searchParameters) 
        {
            int locationIndex = currentText.IndexOf(searchParameters.SearchOption);
            
            if (locationIndex != -1)
            {
                string searchSegment = currentText.Substring(locationIndex + searchParameters.SearchOption.Length, searchParameters.SymbolsCount);
                Regex regex = new Regex(searchParameters.RegexPattern);
                if (regex.IsMatch(searchSegment))
                {
                    string match = regex.Match(searchSegment).Value;
                    estimatesDictionary[searchParameters.EstimateKey].Add(match);
                }
                else
                    estimatesDictionary[searchParameters.EstimateKey].Add("");
            }
            else
                estimatesDictionary[searchParameters.EstimateKey].Add("");
            
            return Task.CompletedTask;
        }
        // тут ад заканчивается (15:48 30.01.2024)

        // Со дна постучали (13:47 02.02.2024)
        private Task SearchRegexAsync(string currentText, SearchParameters searchParameters)
        {
            var regex = new Regex(searchParameters.RegexPattern);
            if (regex.IsMatch(currentText))
            {
                string match = regex.Match(currentText).Value;
                estimatesDictionary[searchParameters.EstimateKey].Add(match);
            }
            else
                estimatesDictionary[searchParameters.EstimateKey].Add("");
            return Task.CompletedTask;
        }

        private Task SearchRegexListAsync(string currentText, SearchParameters searchParameters)
        {
            for (int i = 0; i < searchParameters.RegexPatterns.Count; i++)
            {
                var regex = new Regex(searchParameters.RegexPatterns[i]);
                if (regex.IsMatch(currentText))
                {
                    string match = regex.Match(currentText).Value;
                    estimatesDictionary[searchParameters.EstimateKey].Add(match);
                    return Task.CompletedTask;
                }
            }
            estimatesDictionary[searchParameters.EstimateKey].Add("");

            return Task.CompletedTask;
        }

        private Task SearchByWords(string currentText, string estimateKey)
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}Equipment.txt";

            if (!File.Exists(path))
            {
                MessageBox.Show("Файл оборудования не существует\nБудет создан новый", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.Create(path);
                return Task.CompletedTask;
            }

            using (StreamReader streamReader = new StreamReader(path)) // Чтение файла
            {
                string line;
                while ((line = streamReader.ReadLine()) != null) // Получение слова
                {
                    int locationIndex = currentText.IndexOf(line), // Поиск совпадений
                        charsTo,
                        charsAfter;

                    if (locationIndex != -1)
                    {
                        if (locationIndex >= appParameters.CharactersTo)
                            charsTo = locationIndex;
                        else
                            charsTo = appParameters.CharactersTo - locationIndex;

                        if ((currentText.Length - locationIndex) <= appParameters.CharactersAfter)
                            charsAfter = currentText.Length - locationIndex;
                        else
                            charsAfter = appParameters.CharactersAfter;

                        estimatesDictionary[estimateKey].Add(currentText.Substring(charsTo, charsAfter));
                    }
                }
            }
            return Task.CompletedTask;
        }

        private string ReplaceQuotationMarks(string currentText)
        {
            Regex arrow = new Regex("«");
            currentText = arrow.Replace(currentText, "\"");
            arrow = new Regex("»");
            currentText = arrow.Replace(currentText, "\"");
            return currentText;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MenuPanel.Renderer = new ToolStripProfessionalRenderer(new MenuColors());
        }

        private void SelectFileItem_Click(object sender, EventArgs e)
        {
            openPdfFile.Filter = "Документы формата PDF | *.pdf";

            if (openPdfFile.ShowDialog() == DialogResult.Cancel)
                return;

            debugBox.Clear();
            _filePath = null;

            for (int i = 0; i < estimatesDictionary.Count; i++)
                for (int j = 0; j < estimatesDictionary.ElementAt(i).Value.Count; j++)
                    estimatesDictionary.ElementAt(i).Value.Clear();

            _filePath = openPdfFile.FileName;

            this.Text = "CoRe - " + System.IO.Path.GetFileName(openPdfFile.FileName);

            PDFText(_filePath);
        }

        private void ShowDataGridItem_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm(estimatesDictionary);
            tableForm.Show();
        }

        private void ExportToExcelItem_Click(object sender, EventArgs e)
        {
            saveExcelFile.FileName = $"Экспорт {System.IO.Path.GetFileNameWithoutExtension(openPdfFile.FileName)}";
            saveExcelFile.Filter = "Документы Excel|*.xlsx";

            if (saveExcelFile.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = saveExcelFile.FileName;

            if (File.Exists(fileName) == true)
                File.Delete(fileName);

            TableForm tb = new TableForm(estimatesDictionary);

            var application = new Microsoft.Office.Interop.Excel.Application(); // by Alexey Tolstopyatov
            var book = application.Workbooks.Add(Type.Missing);
            var list = new Worksheet();

            application.Visible = true; // ?

            list = book.Sheets["Лист1"];
            list = book.ActiveSheet;

            list.Name = "Экспорт";

            for (int i = 1; i < TableForm._Table.Columns.Count + 1; i++)
            {
                list.Cells[1, i] = TableForm._Table.Columns[i - 1].HeaderText;
            }

            // storing Each row and column value to excel sheet  
            for (int i = 0; i < TableForm._Table.Rows.Count - 1; i++)
            {
                for (int j = 0; j < TableForm._Table.Columns.Count; j++)
                {
                    if (TableForm._Table.Rows[i].Cells[j].Value != null)
                        list.Cells[i + 2, j + 1] = TableForm._Table.Rows[i].Cells[j].Value.ToString();
                }
            }

            list.Columns.EntireColumn.AutoFit();

            // save the application
            book.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Exit from the application  
            application.Quit();
        }

        private void ShowParametersItem_Click(object sender, EventArgs e)
        {
            ParametersForm parameters = new ParametersForm();
            parameters.ShowDialog();
        }
    }
}
