using System.ComponentModel.DataAnnotations;

namespace sprint_books.ViewModel
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
