using MediatR;
using veterinary_universum_articles.Models;
using veterinary_universum_articles.Repositories;

namespace veterinary_universum_articles.Features.Articles.CreateArticle
{
    public class CreateArticleHandler : IRequestHandler<CreateArticleCommand, Article>
    {
        private readonly IArticleRepository _repository;

        public CreateArticleHandler(IArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Article> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = new Article
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            return await _repository.AddArticleAsync(article, cancellationToken);
        }
    }
}
