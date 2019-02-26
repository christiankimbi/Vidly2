using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required] [MaxLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; } 

        [Required] [Display(Name="Genre")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public byte GenreId { get; set; }

        [Required] [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required] [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Required][Display(Name = "Quantity in Stock")][Range(1,255)]
        public int NumberInStock { get; set; }

      
        public int NumberAvailable { get; set; }
    }

   
}