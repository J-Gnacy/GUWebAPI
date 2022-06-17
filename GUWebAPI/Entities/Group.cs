namespace GUWebAPI.Entities
{
    public record Group
    {
        public Group()
        {
            this.Users = new HashSet<User>();
        }
        public Guid Id { get; init; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
