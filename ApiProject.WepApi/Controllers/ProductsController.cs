using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.ProductDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _apiContext;
        private readonly IValidator<Product> _validator;
        public ProductsController(IMapper mapper, ApiContext apiContext, IValidator<Product> validator)
        {
            _mapper = mapper;
            _apiContext = apiContext;
            _validator = validator;
        }
        [HttpGet("GetList")]
        public IActionResult List()
        {
            var values = _apiContext.Products.ToList();
            return Ok(values);
        }
        [HttpPost("create")]
        public IActionResult Create(Product product)
        {
            var validationProduct = _validator.Validate(product);
            if (!validationProduct.IsValid)
            {
                return BadRequest(validationProduct.Errors.Select(x=>x.ErrorMessage));
            }
            _apiContext.Products.Add(product);
            _apiContext.SaveChanges();
            return Ok("Ürün ekleme işlemi gerçekleşti");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _apiContext.Products.Find(id);
            _apiContext.Products.Remove(value);
            _apiContext.SaveChanges();
            return Ok("Kayıt başarılı bir şekilde silindi.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _apiContext.Products.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult Update(Product product)
        {
            var validateProduct = _validator.Validate(product);
            if (!validateProduct.IsValid)
            {
                return BadRequest("Hata oluştu");
            }

            _apiContext.Products.Update(product);
            _apiContext.SaveChanges();
            return Ok("Kayıt güncellendi");
        }
        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _apiContext.Products.Add(value);
            _apiContext.SaveChanges();
            return Ok("Ekleme işlemi başarılı");

        }

    }
}
