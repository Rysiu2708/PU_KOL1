

using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Student
    {
        public Student(string imie, string nazwisko, int? grupaId)
        {

            Imie = imie;
            Nazwisko = nazwisko;
            GrupaId = grupaId;


        }

        [Key]
        public int Id { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public int? GrupaId { get; set; }

        public Group? Grupa { get; set; }
    }
}
