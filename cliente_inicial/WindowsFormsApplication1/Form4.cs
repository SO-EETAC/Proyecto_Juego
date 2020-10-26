using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        string date;
        public Form4()
        {
            InitializeComponent();
        }
        public string getFecha()
        {
            return date;
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int year = calendar.SelectionRange.Start.Year;
            int month = calendar.SelectionRange.Start.Month;
            int day = calendar.SelectionRange.Start.Day;
            date = year.ToString() + "-" + month.ToString() + "-" + day.ToString();
            Close();
        }
    }
}
