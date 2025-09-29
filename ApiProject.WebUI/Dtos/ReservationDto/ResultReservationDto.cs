﻿namespace ApiProjeKampi.WebUI.Dtos.ReservationDto
{
    public class ResultReservationDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int CountOfPeople { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
