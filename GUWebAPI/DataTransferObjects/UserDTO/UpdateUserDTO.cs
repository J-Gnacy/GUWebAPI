using System.ComponentModel.DataAnnotations;

namespace GUWebAPI.DataTransferObjects
{
    public record UpdateUserDTO
    {
        [Required]
        public string Name { get; init; }
    }
}
