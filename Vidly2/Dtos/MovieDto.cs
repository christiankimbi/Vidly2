using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }



        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 255)]
        public int NumberInStock { get; set; }

    }
}