using MediatR;
using veterinary_universum_articles.Models;
using veterinary_universum_articles.Repositories;

namespace veterinary_universum_articles.Features.Articles.GetAllArticles
{
    public class GetAllArticlesHandler : IRequestHandler<GetAllArticlesQuery, List<Article>>
    {
        private readonly IArticleRepository _repository;

        public GetAllArticlesHandler(IArticleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Article>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }
}
