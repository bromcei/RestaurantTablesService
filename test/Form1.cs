using System.Data.Common;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace test

{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            
            bindingSource1.DataSource = table;
            
            var test = new List<string>() { "alio", "hello" };
            bindingSource1.DataSource = new List<string>() { "alio", "hello" };
            dataGridView1.DataSource = test;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
            


        }
    }
}