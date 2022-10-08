using System.ComponentModel.DataAnnotations;

namespace TatakPinoy.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
