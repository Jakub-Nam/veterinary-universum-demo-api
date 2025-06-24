using MediatR;
using veterinary_universum_articles.Models;

namespace veterinary_universum_articles.Features.Articles.CreateArticle
{
    public record CreateArticleCommand(Article Article) : IRequest<Article>;
}
