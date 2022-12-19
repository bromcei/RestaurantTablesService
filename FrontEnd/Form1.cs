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
            MessageBox.Show($"{selectedRowCount}");
            int personCount;
            string textBoxVal = textBox1.Text;
            if (selectedRowCount == 1 && int.TryParse(textBoxVal, out personCount))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append("Table ID: ");
                    sb.Append(dataGridView1.SelectedRows[i].Cells["TableID"].Value);
                    sb.Append(Environment.NewLine);
                }

                sb.Append("Total: " + selectedRowCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Rows");
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