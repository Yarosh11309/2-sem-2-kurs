namespace sem_2_k_2.Domain.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Prize { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
