using BLL;
using BLL.DTO;
using DAL;
using DAL.Models;

namespace BLL_EF
{
    public class StudentService_EF:IStudentService
    {
        StudentContext context = new StudentContext();

        public void dodajStudenta(DodajStudentaDTO student)
        {
            Student newStudent = new Student(student.Imie, student.Nazwisko, student.GrupaId);

            context.students.Add(newStudent);

            History historia = new History(student.Imie, student.Nazwisko, student.GrupaId, "Dodanie", DateTime.Now);


            context.history.Add(historia);

            context.SaveChanges();
        }

        public void usunStudenta(int id)
        {
            Student? student = context.students.Where(s => s.Id == id).First();

            History historia = new History(student.Imie, student.Nazwisko, student.GrupaId, "Usuniecie", DateTime.Now);

            context.history.Add(historia);
            context.students.Remove(student);
            context.SaveChanges();
        }

        public List<WyswietlStudentaDTO> wyswietlWszystkichStudentow()
        {
            var studenci = context.students.Select(x => new WyswietlStudentaDTO
            {
                Imie = x.Imie,
               Nazwisko = x.Nazwisko,
                Grupa = x.Grupa.Nazwa
            }).ToList();

            return studenci;
        }

        public List<WyswietlHistorieDTO> wyswietlHistorie(int numerStrony, int rozmiarStrony)
        {

            return context.history.Skip((numerStrony - 1) * rozmiarStrony)
    .Take(rozmiarStrony).Select(x => new WyswietlHistorieDTO
    {
        Imie = x.Imie,
        Nazwisko = x.Nazwisko,
        GrupaId = (int)x.GrupaId,
        HistoriaAkcji = x.HistoriakAkcji,
        Data = x.Data
    }).ToList();
        }

        public WyswietlStudentaDTO? wyswietlStudentaPoId(int id)
        {
            return context.students.Where(x => x.Id == id).Select(y=> new WyswietlStudentaDTO
            {
                Imie = y.Imie,
                Nazwisko = y.Nazwisko,
                Grupa = y.Grupa.Nazwa
            }).FirstOrDefault();
        }

        public void edytujStudenta(EdytujStudentaDTO student)
        {
            using (var context = new StudentContext())
            {
                Student studentDoEdycji = context.students.Where(s => s.Id == student.Id).First();

                History historia = new History(studentDoEdycji.Imie, studentDoEdycji.Nazwisko, studentDoEdycji.GrupaId, "Edycja", DateTime.Now);

                context.history.Add(historia);
                
                studentDoEdycji.Imie = student.Imie;
                studentDoEdycji.Nazwisko = student.Nazwisko;
                studentDoEdycji.GrupaId = student.GrupaId;


                context.SaveChanges();
            }
        }
    }
}
