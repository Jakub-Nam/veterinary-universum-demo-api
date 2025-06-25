using MediatR;
using veterinary_universum_articles.Models;
public class CreateArticleCommand : IRequest<Article>
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}