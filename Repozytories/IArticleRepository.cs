using Microsoft.EntityFrameworkCore;
using veterinary_universum_articles.Models;

namespace veterinary_universum_articles.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Articles
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        public async Task<Article?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Articles.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Article> AddArticleAsync(Article article, CancellationToken cancellationToken)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync(cancellationToken);

            return article;
        }
    }
}
