using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViedeoAppFinal.Data;
using ViedeoAppFinal.Interface;
using ViedeoAppFinal.Models;

namespace ViedeoAppFinal.Controllers
{
    public class VideoController : Controller
    {
        private readonly IRepository _repository;
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VideoController(IRepository repository, ApplicationContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            //IList<Video> videos = _context.Videos.Include(g => g.Genres).ToList();
            var model = await _repository.SelectAll<Video>();

            return View(model);
        }

        public async Task<IActionResult> CreateVideo()
        {

            ViewBag.GenreId = new SelectList(await _repository.SelectAll<Genre>(), "GenreId", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(Video video)
        {
            //add image to folder 
            string folder = "videos/cover/";
            folder += Guid.NewGuid().ToString() + "_" + video.CoverPhoto.FileName;
            video.CoverImageUrl = folder;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            await video.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            // save info to db
            var newVideo = new Video() { Name = video.Name, GenreId = video.GenreId, CoverImageUrl = video.CoverImageUrl };
            await _repository.CreateAsync<Video>(newVideo);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVideo(int id) 
        {
           
            ViewBag.GenreId = new SelectList(await _repository.SelectAll<Genre>(), "GenreId", "Name");
            var FindModel = await _repository.SelectById<Video>(id);

            

            return View(FindModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(Video model)
        {
            if (model == null)
            {
                return NotFound();
            }

            if (model.CoverImageUrl != null)
            {
                //add image to folder 
                string folder = "videos/cover/";
               
                folder += Guid.NewGuid().ToString() + "_" + model.CoverPhoto.FileName;

                model.CoverImageUrl = folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await model.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }

            

            ViewBag.SomeId = model.GenreId;
            await _repository.UpdateAsync<Video>(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
