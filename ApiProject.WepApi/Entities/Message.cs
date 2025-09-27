﻿namespace ApiProject.WepApi.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
