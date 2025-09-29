﻿using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.MessageDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;
        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj Silme İşlemi Başarılı");
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Mesaj Güncelleme İşlemi Başarılı");
        }
     
        [HttpGet("ListByIsReadFalse")]
        public IActionResult ListByIsReadFalse()
        {
            var values = (from m in _context.Messages
                          where m.IsRead == false
                          select m).ToList();
            return Ok(values);
        }
    }
}
