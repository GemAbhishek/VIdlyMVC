using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMVC.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [InStockValidation]
        public int Instock { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }

    }
}