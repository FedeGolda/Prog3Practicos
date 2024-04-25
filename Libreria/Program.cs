using System.Data.SqlClient;

namespace Libreria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-FIK9LM4;Initial Catalog=Libreria;Integrated Security=True";
            string query = "INSERT INTO Libro(titulo, descripcion, ID_Autor) VALUES(@param1, @param2, @param3)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@param1", "Titulo del nuevo libro");
                    cmd.Parameters.AddWithValue("@param2", "Descripcion del nuevo libro");
                    cmd.Parameters.AddWithValue("@param3", 1);

                    try
                    {
                        conn.Open();
                        var nFilas = cmd.ExecuteNonQuery();
                        if (nFilas != 1)
                            Console.WriteLine("Error en el numero de filas afectadas");

                        conn.Close();

                        Console.ReadLine();
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

        }
    }
