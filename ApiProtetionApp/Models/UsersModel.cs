using System.ComponentModel.DataAnnotations;

namespace ApiProtetionApp.Models
{
    public class UsersModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; }

        [Phone]
        public string Number { get; set; }

        [Url]
        public string Web { get; set; }
    }
}
