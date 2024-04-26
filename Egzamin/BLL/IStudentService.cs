using BLL.DTO;

namespace BLL
{
    public interface IStudentService
    {
        public void dodajStudenta(DodajStudentaDTO student);

        public void edytujStudenta(EdytujStudentaDTO student);

        public void usunStudenta(int id);

        public List<WyswietlStudentaDTO> wyswietlWszystkichStudentow();

        public WyswietlStudentaDTO wyswietlStudentaPoId(int id);

        public List<WyswietlHistorieDTO> wyswietlHistorie(int numerStrony, int rozmiarStrony);
    }
}
