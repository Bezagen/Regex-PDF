using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFReader
{
    public partial class TableForm : Form
    {
        public static DataGridView _Table;

        public TableForm(Dictionary<string, List<string>> estimatesDictionary)
        {
            InitializeComponent();
            
            for (int i = 0; i < estimatesDictionary["Стр"].Count; i++)
            {
                dataGridView1.Rows.Add();
            }

            /*for (int i = 0; i < estimatesDictionary.Count; i++)
            {
                for (int j = 0; j < estimatesDictionary.ElementAt(i).Value.Count; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = (estimatesDictionary.ElementAt(i).Value[j]);
                }
            }*/
            for (int key = 0; key < estimatesDictionary.Count; key++)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].HeaderText == $"{estimatesDictionary.ElementAt(key).Key}")
                    {
                        for (int j = 0; j < estimatesDictionary.ElementAt(key).Value.Count; j++)
                        {
                            dataGridView1.Rows[j].Cells[i].Value = (estimatesDictionary.ElementAt(key).Value[j]);
                        }
                    }
                }
            }
            _Table = dataGridView1;
        }
    }
}
