using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NS.OBS.Data.Entities
{
    public partial class BookDetail
    {
        [Required(ErrorMessage = "Please enter Id")]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Book Name is Required.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Please Select the image.")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "Please Select the Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Author Name is Required.")]
        [MinLength(3, ErrorMessage = " Name must be atleast 3 characters.")]
        [MaxLength(20, ErrorMessage = "Name must cannot be greter than 15 Characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Publisher name is Required.")]
        [MinLength(3, ErrorMessage = " Publisher Name must be atleast 3 characters.")]
        [MaxLength(50, ErrorMessage = "Description must cannot be greter than 50 Characters")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Description is Required.")]
        [MinLength(3, ErrorMessage = " Description must be atleast 3 characters.")]
        [MaxLength(300, ErrorMessage = "Description must cannot be greter than 300 Characters")]
        public string Description { get; set; }

        //[NotMapped]
        //public IFormFile ImgUrl { get; set; }
    }
}
