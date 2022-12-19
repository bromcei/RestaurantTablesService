using System.Data;
using System.Globalization;
using System.Windows.Forms;
using RestaurantTablesService.Classes;
using RestaurantTablesService.Repositories;
using RestaurantTablesService.Services;

namespace FrontEnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            bindingSource1.DataSource = table;

            OccupyTableService occupyTableService = new OccupyTableService("prod");
            List<Table> tablesList = occupyTableService.ListFreeTables();
            dataGridView1.DataSource = tablesList;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            int personCount;
            string textBoxVal = textBox1.Text;
            if (selectedRowCount == 1 && int.TryParse(textBoxVal, out personCount))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("Total: " + selectedRowCount.ToString());
                MessageBox.Show($"Occupie table {dataGridView1.SelectedRows[0].Cells["TableID"].Value} with {personCount}?");
                dataGridView1.Refresh();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}