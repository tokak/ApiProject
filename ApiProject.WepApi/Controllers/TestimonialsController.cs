using ApiProject.WepApi.Context;
using ApiProject.WepApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;

        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet("GetTestimonialsList")]
        public IActionResult GetTestimonialsList()
        {
            List<Testimonial> values = _context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return Ok("Kategori eklendi");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori Silme İşlemi Başarılı");
        }
        [HttpPut]
        public IActionResult Update(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
