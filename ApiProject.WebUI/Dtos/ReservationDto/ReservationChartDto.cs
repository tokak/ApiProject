﻿namespace ApiProjeKampi.WebUI.Dtos.ReservationDto
{
    public class ReservationChartDto
    {
        public string Month { get; set; }
        public int Approved { get; set; }
        public int Pending { get; set; }
        public int Canceled { get; set; }
    }
}
