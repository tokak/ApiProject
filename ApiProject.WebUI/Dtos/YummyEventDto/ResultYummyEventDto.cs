﻿namespace ApiProject.WebUI.Dtos.YummyEventDto
{
    public class ResultYummyEventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
    }
}
