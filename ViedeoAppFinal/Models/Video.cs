using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViedeoAppFinal.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }
        public int GenreId { get; set; }
        public Genre Genres { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string CoverImageUrl { get; set; }

        [NotMapped]
        public IFormFile CoverPhoto { get; set; }

        public IList<Actor> Actors { get; set; }
    }
}
