using System.ComponentModel.DataAnnotations;

namespace GUWebAPI.DataTransferObjects
{
    public record UpdateGroupDTO
    {
        [Required]
        public string Name { get; init; }
    }
}
