namespace veterinary_universum_articles.Models
{
    public class Article
    {
        public Guid Id { get; set; }               
        public string Title { get; set; } = null!; 
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
