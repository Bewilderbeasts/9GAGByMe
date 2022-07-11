using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Domain
{
    public class Image
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
        // public string Path { get; protected set; }
        public int Rating { get; set; } = 0;
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public IFormFile ImageFile { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }


        protected Image()
        {

        }

        public Image(Guid id, string title, string description, IFormFile imageFile, User user)
        {
            Id = id;
            UserId = user.Id;
            Title = title.ToLowerInvariant();
            Description = description.ToLowerInvariant();
            Rating = 0;
            Filename = imageFile.FileName;
            ImageFile = imageFile;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetTitle(string title)
        {

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("Title is invalid.");
            }
            if (Title == title)
            {
                return;
            }
            Title = title;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Description is invalid.");
            }
            if (Description == description)
            {
                return;
            }
            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }


    }
    
}
