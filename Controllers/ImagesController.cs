using FunnyImages.Commands;
using FunnyImages.Commands.Image;
using FunnyImages.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FunnyImages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ApiControllerBase
    {

        //private readonly IUserService _userService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImagesController(IImageService imageService, /*, IUserService userService,*/
            IWebHostEnvironment webHostEnvironment, ICommandDispatcher commandDispatcher
        ) : base(commandDispatcher)
        {
            //_userService = userService;
            _imageService = imageService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<ImagesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var images = await _imageService.GetAllAsync();

            return Json(images);
        }

        // GET api/<ImagesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var image = await _imageService.GetAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            return Json(image);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] CreateImage image)
        { 
            try
            {
                if (image.ImageFile.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + image.ImageFile.FileName))
                    {
                        image.ImageFile.CopyTo(fileStream);
                        fileStream.Flush();

                        await DispatchAsync(image);
                        return Created($"images/{image.Title}", null);
                    }

                }
                else { throw new Exception("Couldn't create a new image"); }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> PostFile([FromForm] UploadImage image, [FromBody] UploadImage command)
        //{
        //    await DispatchAsync(command);

        //    try
        //    {
        //        if (image.ImageFile.Length > 0)
        //        {
        //            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
        //            if (!Directory.Exists(path))
        //            {
        //                Directory.CreateDirectory(path);
        //            }
        //            using (FileStream fileStream = System.IO.File.Create(path + image.ImageFile.FileName) )
        //            {
        //                image.ImageFile.CopyTo(fileStream);
        //                fileStream.Flush();
        //                return Created($"images/{command.UserId}", null);
        //            }
                   
        //        }
        //        else { return NoContent(); }
        //    }
        //    catch (Exception ex)
        //    {

        //        return NotFound();
        //    }
        //    //return Created($"images/{command.UserId}", null);

        //}

        // PUT api/<ImagesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
