using BLL;
using BLL.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BLL_DB
{
    public class StudentService_DB:IStudentService
    {

        public void dodajStudenta(DodajStudentaDTO student)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PUKOL1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
         
                connection.Open();

         
                using (SqlCommand command = new SqlCommand("dbo.DodajStudenta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure; 
               
                    command.Parameters.AddWithValue("@Imie", student.Imie);
                    command.Parameters.AddWithValue("@Nazwisko", student.Nazwisko);
                    command.Parameters.AddWithValue("@GrupaId", student.GrupaId);
                    command.ExecuteNonQuery();
                }
            }
            
        }

        public void edytujStudenta(EdytujStudentaDTO student)
        {
            throw new NotImplementedException();
        }

        public void usunStudenta(int id)
        {
            throw new NotImplementedException();
        }

        public List<WyswietlHistorieDTO> wyswietlHistorie(int numerStrony, int rozmiarStrony)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PUKOL1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            List<WyswietlHistorieDTO> historie = new List<WyswietlHistorieDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("dbo.WyswietlHistorie", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NumerStrony", numerStrony);
                    command.Parameters.AddWithValue("@RozmiarStrony", rozmiarStrony);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WyswietlHistorieDTO historia = new WyswietlHistorieDTO();
                            historia.Imie = reader["Imie"].ToString();
                            historia.Nazwisko = reader["Nazwisko"].ToString();
                            historia.GrupaId = (int)reader["GrupaId"];
                            historia.HistoriaAkcji = reader["HistoriakAkcji"].ToString();
                            historia.Data = Convert.ToDateTime(reader["Data"]);

                            historie.Add(historia);
                        }
                    }
                }
            }
            return historie;
        }

        public WyswietlStudentaDTO wyswietlStudentaPoId(int id)
        {
            throw new NotImplementedException();
        }

        public List<WyswietlStudentaDTO> wyswietlWszystkichStudentow()
        {
            throw new NotImplementedException();
        }
    }
}
