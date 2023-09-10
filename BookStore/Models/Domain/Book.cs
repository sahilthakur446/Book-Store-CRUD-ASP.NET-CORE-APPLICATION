using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models.Domain
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int ? TotalPages { get; set; }
        [Required]
        [Display(Name ="Author")]
        public int AuthorId { get; set; }
        [Required]
        [Display(Name ="Publisher")]
        public int PublisherId { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [NotMapped]
        [Display(Name = "Author Name")]
        public string ? AuthorName { get; set; }
        [NotMapped]
        [Display(Name = "Publisher Name")]
        public string ? PublisherName { get; set; }
        [NotMapped]
        [Display(Name = "Genre Name")]
        public string ? GenreName { get; set; }
        [NotMapped]
        public List<SelectListItem> ? AuthorList { get; set; }
        [NotMapped]
        public List<SelectListItem> ? PublisherList { get; set; }
        [NotMapped]
        public List<SelectListItem> ? GenreList { get; set; }

    }
}
