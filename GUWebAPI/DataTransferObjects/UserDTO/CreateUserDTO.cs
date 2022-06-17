using System.ComponentModel.DataAnnotations;

namespace GUWebAPI.DataTransferObjects
{
    public record CreateUserDTO
    {
        [Required]
        public string Name { get; init; }
    }
}
