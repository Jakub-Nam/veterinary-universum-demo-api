using MediatR;
using veterinary_universum_articles.Models;

namespace veterinary_universum_articles.Features.Articles.GetAllArticles
{
    public record GetAllArticlesQuery : IRequest<List<Article>>;
}
