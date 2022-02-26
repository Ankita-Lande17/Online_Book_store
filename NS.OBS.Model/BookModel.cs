using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NS.OBS.Model
{
    public class BookModel
    {
        [Key]
        [Required(ErrorMessage = "BId is Required.")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book Name is Required.")]
        public string BookName { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "Author Name is Required.")]
        [MinLength(3, ErrorMessage = " Name must be atleast 3 characters.")]
        [MaxLength(20, ErrorMessage = "Name must cannot be greter than 15 Characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Publisher name is Required.")]
        [MinLength(3, ErrorMessage = " Publisher Name must be atleast 3 characters.")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Description is Required.")]
        [MinLength(3, ErrorMessage = " Description must be atleast 3 characters.")]
        [MaxLength(100, ErrorMessage = "Description must cannot be greter than 100 Characters")]
        public string Description { get; set; }
		
		
        [NotMapped]
        public IFormFile BookPhoto { get; set; }
		
		public string ImgUrl { get; set; }
    }
}
