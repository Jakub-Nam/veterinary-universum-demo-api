using MediatR;
using veterinary_universum_articles.Features.Articles.CreateArticle;
using veterinary_universum_articles.Models;
using veterinary_universum_articles.Repositories;

public class CreateArticleHandler : IRequestHandler<CreateArticleCommand, Article>
{
    private readonly IArticleRepository _repository;

    public CreateArticleHandler(IArticleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Article> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        return await _repository.AddArticleAsync(request.Article, cancellationToken);
    }
}
