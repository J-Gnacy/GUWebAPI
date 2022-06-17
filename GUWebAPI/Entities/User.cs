namespace GUWebAPI.Entities
{
    public record User
    {
        public User()
        {
            this.Groups = new HashSet<Group>();
        }

        public Guid Id { get; init; }
        public string Name { get; set; }
        public virtual ICollection<Group> Groups { get; set; }

    }
}
