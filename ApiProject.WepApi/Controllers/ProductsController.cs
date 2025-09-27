using ApiProject.WepApi.Context;
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
        [HttpPost]
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
    }
}
