using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sprint_books.Models;

public partial class Book
{
    public int BookId { get; set; }
    [Required]
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Language { get; set; }

    [Required]
    public string? Isbn { get; set; }

    [Required,
      Display(Name = "Date Published")]
   
    public DateTime? DatePublished { get; set; }

    [Required,
        DataType(DataType.Currency)]
    public int? Price { get; set; }
    [Required]
    public string? Author { get; set; }

    [Display(Name = "Image Url")]
    public string? ImageUrl { get; set; }

   
}
/*Code Attribute
* Source:https://youtu.be/3rAD03PFQlQ?si=ZBh2GEcJz4-9o8mE
* Creater :LearnWithMe#1 Bokhandel Webbshop|ASP.NET Core MVC Projekt
*/
