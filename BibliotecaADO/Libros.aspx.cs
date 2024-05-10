﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaADO
{
    public partial class Libros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarLibros(string busqueda, string criterio)
        {
            // string connectionString = "Data Source=DESKTOP-FIK9LM4;Initial Catalog=Libreria;Integrated Security=True"; // NOMBRE DE LA NOTEBOOK
            string connectionString = "Data Source=PC-FEDE;Initial Catalog=Libreria;Integrated Security=True"; // NOMBRE DE LA PC
            string query = $"SELECT titulo, descripcion, ID_Autor, anio FROM Libro WHERE {criterio} LIKE @busqueda";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                    conn.Close();

                    gvResultados.DataSource = dt;
                    gvResultados.DataBind();
                }
                catch (Exception ex)
                {
                    // Consider logging the error or displaying a message to the user
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = ddlTipoBusqueda.SelectedValue;
            switch (criterio)
            {
                case "Autor":
                    criterio = "ID_Autor";
                    break;
                case "Titulo":
                    criterio = "titulo";
                    break;
                case "Año":
                    criterio = "anio";
                    break;
            }

            BuscarLibros(txtBuscar.Text, criterio);
        }
    }
}