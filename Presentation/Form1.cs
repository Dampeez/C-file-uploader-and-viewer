using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLink;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            DataLink.Helper helper = new Helper();
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse Text File",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "csv",
                InitialDirectory = "C:\\",
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

                Helper.file = textBox1.Text;

                dataGridView1.DataSource = Helper.DataTableFromTextFile(textBox1.Text);
                MessageBox.Show("Data Loaded Successfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
