namespace GUWebAPI.DataTransferObjects
{
    public record GroupDTO
    {
        public Guid Id { get; init; }

        public string Name { get; init; }
    }
}
