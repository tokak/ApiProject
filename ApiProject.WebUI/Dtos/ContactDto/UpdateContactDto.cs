﻿namespace ApiProjeKampi.WebUI.Dtos.ContactDto
{
    public class UpdateContactDto
    {
        public int Id { get; set; }
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpenHours { get; set; }
    }
}
