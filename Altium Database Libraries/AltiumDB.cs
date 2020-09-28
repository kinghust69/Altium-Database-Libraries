using Altium_Database_Libraries.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Altium_Database_Libraries
{
    public partial class AltiumDB : Form
    {
        public AltiumDB()
        {
            InitializeComponent();
            dataview.RowsDefaultCellStyle.BackColor = System.Drawing.Color.Bisque;
            dataview.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige;
            dataview.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataview.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Red;
            dataview.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataview.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (DataGridViewColumn item in dataview.Columns)
            {
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SQLData test = new SQLData("Huan.db");
            dataview.DataSource = test.SQLDataView().DataSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HTMLData htmlTool = new HTMLData();
            richTextBox1.Text = htmlTool.GetHtml(@"http://www.digikey.com/product-detail/en/stmicroelectronics/UC3845BN/497-14808-5-ND/1852682");
            richTextBox2.Text = htmlTool.GetData(richTextBox1.Text, "<meta itemprop=\"productID\" content=\"sku:", "\" />")[0];
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<span itemprop=\"name\">", "</span>")[0].Trim());
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<th>Manufacturer Part Number</th>\n                                <td>\n", "\n")[0].Trim());
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<td itemprop=\"description\">\n", "\n")[0].Trim());
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<span itemprop=\"name\">", "</span>")[0]);
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<span itemprop=\"name\">", "</span>")[0]);
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<span itemprop=\"name\">", "</span>")[0]);
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<span itemprop=\"name\">", "</span>")[0]);
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<span itemprop=\"name\">", "</span>")[0]);
            richTextBox2.AppendText("\n" + htmlTool.GetData(richTextBox1.Text, "<span itemprop=\"name\">", "</span>")[0]);
        }
    }
}
