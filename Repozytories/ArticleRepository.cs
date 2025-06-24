using veterinary_universum_articles.Models;

namespace veterinary_universum_articles.Repositories
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllAsync(CancellationToken cancellationToken);
        Task<Article?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        // nie rozumiem czemu chce ?
        Task<Article> AddArticleAsync(Article article, CancellationToken cancellationToken);

    }
}
