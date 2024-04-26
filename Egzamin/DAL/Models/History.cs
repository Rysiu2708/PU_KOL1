using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class History
    {
        public History(string imie, string nazwisko, int? grupaId, string historiakAkcji, DateTime data)
        {

            Imie = imie;
            Nazwisko = nazwisko;
            GrupaId = grupaId;
            HistoriakAkcji = historiakAkcji;
            Data = data;
            

        }

        [Key]
            public int Id { get; set; }

            public string Imie { get; set; }

            public string Nazwisko { get; set; }

            public int? GrupaId { get; set; }

            public Group? Grupa { get; set; }

            public string HistoriakAkcji { get; set; }

            public DateTime Data { get; set; }
        


    }
}
