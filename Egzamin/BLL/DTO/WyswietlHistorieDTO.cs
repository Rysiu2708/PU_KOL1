using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class WyswietlHistorieDTO
    {

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public int GrupaId { get; set; }

        public string HistoriaAkcji { get; set; }

        public DateTime Data { get; set; }
    }
}
