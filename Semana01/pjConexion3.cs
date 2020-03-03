﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Semana01
{
    public partial class pjConexion3 : Form
    {
        public pjConexion3()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Kevin"].ConnectionString);

        public void ListaProductos()
        {
            using (SqlDataAdapter Df = new SqlDataAdapter("Usp_ListaProductos_Neptuno", cn))
            {
                using (DataSet Da = new DataSet())
                {
                    Df.Fill(Da, "Productos");
                    dgProductos.DataSource = Da.Tables["Productos"];
                    lblCantidad.Text = Da.Tables["Productos"].Rows.Count.ToString();
                }
            }
        }

        private void pjConexion3_Load(object sender, EventArgs e)
        {
            ListaProductos();
        }
    }
}
