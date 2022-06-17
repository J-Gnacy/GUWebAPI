namespace GUWebAPI.DataTransferObjects
{
    public record UserDTO
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}
