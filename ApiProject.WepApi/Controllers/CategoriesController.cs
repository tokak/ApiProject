using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.CategoryDto;
using ApiProject.WepApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetCategoriesList")]
        public IActionResult GetCategoriesList()
        {
            List<Category> values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto category)
        {
            var map = _mapper.Map<Category>(category);
            _context.Categories.Add(map);
            _context.SaveChanges();
            return Ok("Kategori eklendi");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori Silme İşlemi Başarılı");
        }
        [HttpPut]
        public IActionResult Update(UpdateCategoryDto category)
        {
            var map = _mapper.Map<Category>(category);
            _context.Categories.Update(map);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }

    }
}
