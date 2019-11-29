using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalPortal.Dtos
{
    public class MovieDto
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string MovieName { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }
        public GenreDto Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }
    }
}