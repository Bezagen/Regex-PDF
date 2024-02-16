using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFReader.Structures;

namespace PDFReader
{
    public partial class ParametersForm : Form
    {
        AppParameters appParameters = new AppParameters();

        public ParametersForm()
        {
            InitializeComponent();

            CharsBeforeWord.Text = appParameters.CharactersTo.ToString();
            CharsAfterWord.Text = appParameters.CharactersAfter.ToString();
        }

        private void AplyButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(CharsBeforeWord.Text) <= 40 && Convert.ToInt32(CharsAfterWord.Text) <= 40)
            {
                appParameters.CharactersTo = Convert.ToInt32(CharsBeforeWord.Text);
                appParameters.CharactersAfter = Convert.ToInt32(CharsAfterWord.Text);
                appParameters.SaveParameters();
                MessageBox.Show("Сохранено", "Успех", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Не более 40 символов в одну сторону", "Внимание", MessageBoxButtons.OK);
                CharsBeforeWord.Text = "40";
                CharsAfterWord.Text = "40";
                appParameters.CharactersTo = 40;
                appParameters.CharactersAfter = 40;
                appParameters.SaveParameters();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CharsBeforeWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void CharsAfterWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void CharsBeforeWord_TextChanged(object sender, EventArgs e)
        {
        }

        private void CharsAfterWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void EquipmentButton_Click(object sender, EventArgs e)
        {
            if(File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Equipment.txt"))
                Process.Start(AppDomain.CurrentDomain.BaseDirectory+"Equipment.txt");
            else
            {
                MessageBox.Show("Файл оборудования не существует\nБудет создан новый", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "Equipment.txt");
            }
        }
    }
}
