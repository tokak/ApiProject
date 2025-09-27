using ApiProject.WepApi.Context;
using ApiProject.WepApi.Dtos.ContactDtos;
using ApiProject.WepApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet("GetContactList")]
        public IActionResult List()
        {
            List<Contact> values = _context.Contacts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
            Address = createContactDto.Address,
            Email =createContactDto.Email,
            MapLocation = createContactDto.MapLocation,
            OpenHours = createContactDto.OpenHours,
            Phone = createContactDto.Phone
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var contact = _context.Contacts.FirstOrDefault(x=>x.Id == updateContactDto.Id);
            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.OpenHours = updateContactDto.OpenHours;
            contact.MapLocation = updateContactDto.MapLocation;

            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
