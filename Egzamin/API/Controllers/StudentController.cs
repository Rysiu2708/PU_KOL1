using BLL.DTO;
using BLL_EF;
using BLL_DB;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private StudentService_EF serviceEF = new StudentService_EF();
        private StudentService_DB serviceDB = new StudentService_DB();

        [HttpGet]
        public List<WyswietlStudentaDTO> wyswietlStudentow()
        {
            return serviceEF.wyswietlWszystkichStudentow();
        }
        [Route("{id}")]
        [HttpGet]
        public WyswietlStudentaDTO? wyswietlStudentaPoId([FromRoute] int id)
        {
            return serviceEF.wyswietlStudentaPoId(id);
        }
        
        [HttpPost]
        public void dodajStudenta([FromBody] DodajStudentaDTO student)
        {
            serviceEF.dodajStudenta(student);
        }

        [HttpDelete]
        public void usunStudenta(int id)
        {
            serviceEF.usunStudenta(id);
        }

        [HttpPut]
        public void edytujStudenta([FromBody] EdytujStudentaDTO student)
        {
            serviceEF.edytujStudenta(student);
        }

        [Route("historia")]
        [HttpGet]
        public List<WyswietlHistorieDTO> wyswietlHistorie([FromQuery] int page, [FromQuery] int pageSize)
        {
            return serviceEF.wyswietlHistorie(page, pageSize);
        }

        [HttpPost]
        [Route("dodajStudentadb")]
        public void dodajStudentaProcedure([FromBody] DodajStudentaDTO student)
        {
            serviceDB.dodajStudenta(student);
        }

        [HttpGet]
        [Route("historiadb")]
        public List<WyswietlHistorieDTO> wyswietlHistorieProcedure([FromQuery] int page, [FromQuery] int pageSize)
        {
            return serviceDB.wyswietlHistorie(page, pageSize);
        }
    }
}
