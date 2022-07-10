using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Domain
{
    public class Comment
    {
        public Guid Id { get; protected set; }
        public Guid ImageId { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public Comment(Guid id,  string content, User user, Image image)
        {
            Id = id;
            ImageId = image.Id;
            UserId = user.Id;
            Content = content;
        }

        public void SetContent(string content)
        {
            if ((string.IsNullOrWhiteSpace(content)))
            {
                throw new Exception("Comment cannot be empty!");
            }
            else if (content.Length >= 240)
            {
                throw new Exception("Comment cannot be longer than 240 characters!");
            }
            Content = content;
            UpdatedAt = DateTime.UtcNow;
        }


    }

}
