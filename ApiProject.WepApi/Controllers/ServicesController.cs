using ApiProject.WepApi.Context;
using ApiProject.WepApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet("GetServiceList")]
        public IActionResult GetServiceList()
        {
            List<Service> values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(Service Service)
        {
            _context.Services.Add(Service);
            _context.SaveChanges();
            return Ok("Kategori eklendi");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori Silme İşlemi Başarılı");
        }
        [HttpPut]
        public IActionResult Update(Service Service)
        {
            _context.Services.Update(Service);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
