using MediatR;
using veterinary_universum_articles.Models;
using veterinary_universum_articles.Repositories;

namespace veterinary_universum_articles.Features.Articles.GetArticle
{
    public class GetArticleHandler : IRequestHandler<GetArticleQuery, Article?>
    {
        private readonly IArticleRepository _repository;

        public GetArticleHandler(IArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Article?> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
