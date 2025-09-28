using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.NotificationDtos;
using ApiProject.WepApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public NotificationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetNotficationList")]
        public IActionResult GetNotficationList()
        {
            List<Notification> values = _context.Notifications.ToList();
            List<ResultNotificationDto> map = _mapper.Map<List<ResultNotificationDto>>(values);
            return Ok(map);
        }

        [HttpPost]
        public IActionResult Create(CreateNotificationDto createNotificationDto)
        {
            var map = _mapper.Map<Notification>(createNotificationDto);
            _context.Notifications.Add(map);
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

        [HttpGet("GetNotification")]
        public IActionResult GetNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            var map = _mapper.Map<GetNotificationByIdDto>(value);
            return Ok(map);
        }

        [HttpPut]
        public IActionResult Update(UpdateNotificationDto updateNotificationDto)
        {
            var map = _mapper.Map<Notification>(updateNotificationDto);
            _context.Notifications.Update(map);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
