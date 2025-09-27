using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.ContactDtos;
using ApiProject.WepApi.Dtos.FeatureDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetFeatureList")]
        public IActionResult List()
        {
            List<Feature> values = _context.Features.ToList();
            List<ResultFeatureDto> map = _mapper.Map<List<ResultFeatureDto>>(values);
            return Ok(map);
        }

        [HttpPost]
        public IActionResult Create(CreateFeatureDto createFeatureDto)
        {
            var map = _mapper.Map<Feature>(createFeatureDto);          
            _context.Features.Add(map);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            var map = _mapper.Map<GetByIdFeatureDto>(value);
            return Ok(map);
        }

        [HttpPut]
        public IActionResult Update(UpdateFeatureDto updateFeatureDto)
        {
            var contact = _context.Features.FirstOrDefault(x => x.Id == updateFeatureDto.Id);
            var map = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(map);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
