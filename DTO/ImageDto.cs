﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.DTO
{
    public class ImageDto
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
        public int Rating { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public IFormFile ImageFile { get; set; }
    }
}
