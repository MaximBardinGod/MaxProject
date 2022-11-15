using Microsoft.AspNetCore.Mvc;
using TP3.Models;
using TP3.Service;
using TP3.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace TP3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private IRepairService client { get; set; }
        private IBaseRepository<Mentor> Typeofworks { get; set; }

        public Controller(IRepairService fillService, IBaseRepository<Mentor> mentor)
        {
            FillService = fillService;
            Typeofworks = mentor;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Typeofworks.GetAll());
        }

        [HttpPost]
        public JsonResult Post()
        {
            FillService.Fill();
            return new JsonResult("Work was successfully done");
        }

        [HttpPut]
        public JsonResult Put(Mentor doc)
        {
            bool success = true;
            var typeofwork = Typeofworks.Get(doc.Id);
            try
            {
                if (typeofwork != null)
                {
                    typeofwork = Typeofworks.Update(doc);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {typeofwork.Id}") : new JsonResult("Update was not successful");
        }

        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            bool success = true;
            var typeofwork = Typeofworks.Get(id);

            try
            {
                if (typeofwork != null)
                {
                    Typeofworks.Delete(typeofwork.Id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }
    }
}
