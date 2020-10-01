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
            string html, temp;
           
            html = htmlTool.GetHtml(textBox1.Text.Trim());

            richTextBox1.Text = html;
            richTextBox2.Text = "Digi - Key Part Number: " + htmlTool.GetData(richTextBox1.Text, "<meta itemprop=\"productID\" content=\"sku:", "\" />")[0];
            richTextBox2.AppendText("\nManufacturer: " + htmlTool.GetData(richTextBox1.Text, "<span itemprop=\"name\">", "</span>")[0].Trim());
            richTextBox2.AppendText("\nManufacturer Part Number: " + htmlTool.GetData(richTextBox1.Text, "<th>Manufacturer Part Number</th><td>", "</td>")[0].Trim());
            richTextBox2.AppendText("\nDescription: " + htmlTool.GetData(richTextBox1.Text, "<td itemprop=\"description\">", "</td>")[0].Trim());
            richTextBox2.AppendText("\nManufacturer Standard Lead Time: " + htmlTool.GetData(richTextBox1.Text, "<th>Manufacturer Standard Lead Time</th><td><span>", "</span>")[0]);
            richTextBox2.AppendText("\nDetailed Description: " + htmlTool.GetData(richTextBox1.Text, "<h3 itemprop=\"description\">", "</h3>")[0]);
            temp = htmlTool.GetData(richTextBox1.Text, "<td class=\"attributes-td-categories-link\">", "</a>")[0];
            temp = temp.Remove(temp.IndexOf("<"), temp.IndexOf(">") + 1);
            richTextBox2.AppendText("\nCategories: " + temp);
            temp = htmlTool.GetData(richTextBox1.Text, "<td class=\"attributes-td-categories-link\">", "</a>")[1];
            temp = temp.Remove(temp.IndexOf("<"), temp.IndexOf(">") + 1);
            richTextBox2.AppendText("\n" + temp);
            richTextBox2.AppendText("\nOperating Temperature: " + htmlTool.GetData(richTextBox1.Text, "<th>Operating Temperature</th><td>", "</td>")[0]);
            richTextBox2.AppendText("\nMounting Type: " + htmlTool.GetData(richTextBox1.Text, "<th>Mounting Type</th><td>", "</td>")[0]);
            richTextBox2.AppendText("\nPackage / Case: " + htmlTool.GetData(richTextBox1.Text, "<th>Package / Case</th><td>", "</td>")[0]);
            richTextBox2.AppendText("\nSupplier Device Package: " + htmlTool.GetData(richTextBox1.Text, "<th>Supplier Device Package</th><td>", "</td>")[0]);
        }
    }
}
