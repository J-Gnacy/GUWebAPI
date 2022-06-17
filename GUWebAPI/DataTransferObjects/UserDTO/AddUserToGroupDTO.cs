using System.ComponentModel.DataAnnotations;

namespace GUWebAPI.DataTransferObjects

{
    public record AddUserToGroupDTO
    {
        [Required]
        public Guid UserID { get; init; }
    }
}
