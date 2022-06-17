using System.ComponentModel.DataAnnotations;

namespace GUWebAPI.DataTransferObjects
{
    public record CreateGroupDTO
    {
        [Required]
        public string Name { get; init; }
    }
}
