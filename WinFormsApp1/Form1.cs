using Npgsql;
using System.Data;
namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		public static List<string> tabNames = new List<string>();
		public static List<DataGridView> dataGrids = new List<DataGridView>();
		private void Form1_Load(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = Program.DBC.GetConnection().GetSchema("TABLEs");
			foreach(DataRow dr in dt.Rows)
			{
				if (dr[2].ToString() != "systemtable")
				{
					tabNames.Add(dr[2].ToString());
					tabControl1.TabPages.Add(tabNames[dt.Rows.IndexOf(dr)]);
					tabControl1.TabPages[dt.Rows.IndexOf(dr)].Controls.Add(addDatagridview(dt.Rows.IndexOf(dr)));
				}
			}
		}
		public static DataGridView addDatagridview(int index)
		{
			DataGridView data = new DataGridView();
			data.ColumnHeadersVisible = true;
			data.Name = "dynDGR";
			data.Dock = DockStyle.Fill;
			DataTable dataTable = new DataTable();
			NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter("SELECT * FROM " + tabNames[index], Program.DBC.GetConnection());
			npgsqlDataAdapter.Fill(dataTable);
			data.DataSource = dataTable;
			dataGrids.Add(data);
			return data;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataTable dataTable = new DataTable();
			dataTable = (DataTable)dataGrids[tabControl1.SelectedIndex].DataSource;
			NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM "+tabNames[tabControl1.SelectedIndex], Program.DBC.GetConnection());
			NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(da);
			builder.GetInsertCommand();
			builder.GetUpdateCommand();
			builder.GetDeleteCommand();
			
			da.Update(dataTable);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DataTable dataTable = new DataTable();
			foreach(string tabname in tabNames)
			{

				dataTable = (DataTable)dataGrids[tabNames.IndexOf(tabname)].DataSource;
				NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM " + tabname, Program.DBC.GetConnection());
				NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(da);
				builder.GetInsertCommand();
				builder.GetUpdateCommand();
				builder.GetDeleteCommand();

				da.Update(dataTable);

			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			NpgsqlCommand command = new NpgsqlCommand();
			command.CommandText = richTextBox1.Text;
			command.Connection = Program.DBC.GetConnection();
			try
			{
				dt.Load(command.ExecuteReader());
				dataGridView1.DataSource = dt;
			}
			catch(Exception exc)
            {
				MessageBox.Show(exc.Message);
            }
		}
	
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Program.DBC.closeConnection();
		}
	}
	
}