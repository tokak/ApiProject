﻿namespace ApiProject.WebUI.Dtos.TestimonialDto
{
    public class GetTestimonialByIdDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
