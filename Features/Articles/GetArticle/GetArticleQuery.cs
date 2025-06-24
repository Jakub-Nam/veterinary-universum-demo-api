using MediatR;
using veterinary_universum_articles.Models;

namespace veterinary_universum_articles.Features.Articles.GetArticle
{
    public record GetArticleQuery(Guid Id) : IRequest<Article>;
}
