using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Semana01
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection =new SqlConnection("Data Source = (local);Initial " +
            "Catalog=Neptuno;Integrated Security=True");

        public void ListaClientes()
        {
            using (SqlDataAdapter Df = new SqlDataAdapter("Select * from Clientes", sqlConnection))
            {
                using (DataSet Da = new DataSet())
                {
                    Df.Fill(Da, "Clientes");
                    DgClientes.DataSource = Da.Tables["Clientes"];
                    lblTotal.Text = Da.Tables["Clientes"].Rows.Count.ToString();
                }
            }
        }

        private void DgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            ListaClientes();
        }
    }
}
