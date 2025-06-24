using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using veterinary_universum_articles.Features.Articles.CreateArticle;
using veterinary_universum_articles.Models;

namespace veterinary_universum_articles.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticlesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ArticlesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /api/articles
    [HttpGet]
    public async Task<IActionResult> GetArticles()
    {
        var articles = await _context.Articles.ToListAsync();
        return Ok(articles);
    }
}

[ApiController]
[Route("api/article")]
public class ArticleController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public ArticleController(AppDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetArticle(int id)
    {
        var article = await _context.Articles.FindAsync(id);
        if (article == null)
            return NotFound();
        return Ok(article);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle([FromBody] Article article)
    {
        var created = await _mediator.Send(new CreateArticleCommand(article));
        return CreatedAtAction(nameof(CreateArticle), new { id = created.Id }, created);
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateArticle(Guid id, [FromBody] Article article)
    //{
    //    if (id != article.Id)
    //        return BadRequest();

    //    _context.Entry(article).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!_context.Articles.Any(a => a.Id == id))
    //            return NotFound();
    //        else
    //            throw;
    //    }

    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteArticle(int id)
    //{
    //    var article = await _context.Articles.FindAsync(id);
    //    if (article == null)
    //        return NotFound();

    //    _context.Articles.Remove(article);
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}
}
