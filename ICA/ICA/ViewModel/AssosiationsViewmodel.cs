﻿using ICA.Models;

namespace ICA.ViewModel
{
    public class AssosiationsViewmodel
    {
        public int Id { get; set; }
        public string? AssosiationURL { get; set; }
        public string? FullName { get; set; }
        public string? FullNameEnglish { get; set; }
        public string? Photo { get; set; }
        public IFormFile? PhotoFile { get; set; }
        public string? About { get; set; }
        public string? AboutEnglish { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaceBookLink { get; set; }
        public string? Manger { get; set; }
        public ICollection<projects>? Projects { get; set; }
        public ICollection<Member>? Members { get; set; }
        public ICollection<Article>? Articles { get; set; }
    }
}