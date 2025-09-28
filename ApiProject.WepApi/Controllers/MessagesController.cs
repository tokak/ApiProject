using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.MessageDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _apiContext;
        public MessagesController(IMapper mapper, ApiContext apiContext)
        {
            _mapper = mapper;
            _apiContext = apiContext;
        }
        [HttpGet("GetList")]
        public IActionResult List()
        {
            var values = _apiContext.Messages.ToList();
            var map = _mapper.Map<ResultMessageDto>(values);
            return Ok(map);
        }
        [HttpPost]
        public IActionResult Create(CreateMessageDto createMessageDto) 
        {
            var map = _mapper.Map<Message>(createMessageDto);
            _apiContext.Messages.Add(map);
            return Ok("Kayıt gerçekleştirildi.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var message = _apiContext.Messages.Find(id);
            _apiContext.Messages.Remove(message);
            return Ok("Kayıt başarılı ile silindi");
        }
        [HttpPut]
        public IActionResult Update(UpdateMessageDto updateMessageDto)
        {
            var map = _mapper.Map<Message>(updateMessageDto);
            _apiContext.Messages.Update(map);
            _apiContext.SaveChanges();
            return Ok("Kayıt güncellendi.");
            
        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var message = _apiContext.Messages.Find(id);
            var map = _mapper.Map<GetByIdMessageDto>(message);
            return Ok(map);
        }

        [HttpGet("ListByIsReadFalse")]
        public IActionResult ListByIsReadFalse()
        {
            var values = (from m in _apiContext.Messages
                         where m.IsRead == false
                         select m).ToList();
            return Ok(values);
        }
    }
}
