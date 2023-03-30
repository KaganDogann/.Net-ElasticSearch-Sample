
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost("sample")]
    public async Task<IActionResult> PostSampleData()
    {
        await _postService.InsertManyAsync();

        return Ok(new { Result = "Data successfully registered with Elasticsearch" });
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _postService.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("name-match")]
    public async Task<IActionResult> GetByNameWithMatch([FromQuery] string name)
    {
        var result = await _postService.GetByNameWithMatch(name);

        return Ok(result);
    }

    [HttpGet("name-multimatch")]
    public async Task<IActionResult> GetByNameAndDescriptionMultiMatch([FromQuery] string term)
    {
        var result = await _postService.GetByNameAndDescriptionWithMultiMatch(term);

        return Ok(result);
    }

    [HttpGet("name-matchphrase")]
    public async Task<IActionResult> GetByNameWithMatchPhrase([FromQuery] string name)
    {
        var result = await _postService.GetByNameWithMatchPhrase(name);

        return Ok(result);
    }

    [HttpGet("name-matchphraseprefix")]
    public async Task<IActionResult> GetByNameWithMatchPhrasePrefix([FromQuery] string name)
    {
        var result = await _postService.GetByNameWithMatchPhrasePrefix(name);

        return Ok(result);
    }

    [HttpGet("name-term")]
    public async Task<IActionResult> GetByNameWithTerm([FromQuery] string name)
    {
        var result = await _postService.GetByNameWithTerm(name);

        return Ok(result);
    }

    [HttpGet("name-wildcard")]
    public async Task<IActionResult> GetByNameWithWildcard([FromQuery] string name)
    {
        var result = await _postService.GetByNameWithWilcard(name);

        return Ok(result);
    }

    [HttpGet("name-fuzzy")]
    public async Task<IActionResult> GetByNameWithFuzzy([FromQuery] string name)
    {
        var result = await _postService.GetByNameWithFuzzy(name);

        return Ok(result);
    }

    [HttpGet("description-match")]
    public async Task<IActionResult> GetByDescriptionMatch([FromQuery] string description)
    {
        var result = await _postService.GetByDescriptionMatch(description);

        return Ok(result);
    }

    [HttpGet("all-fields")]
    public async Task<IActionResult> SearchAllProperties([FromQuery] string term)
    {
        var result = await _postService.SearchInAllFields(term);

        return Ok(result);
    }

    [HttpGet("term")]
    public async Task<IActionResult> GetByAllCondictions([FromQuery] string term)
    {
        var result = await _postService.GetPostsAllCondition(term);

        return Ok(result);
    }

    [HttpGet("create-Index")]
    public async Task<IActionResult> CreateIndex()
    {
        var result = await _postService.CreateIndex();
        return Ok(result);
    }
    [HttpPost("insert-actor")]
    public async Task<IActionResult> InsertActor(IndexPosts actor)
    {
        var result = await _postService.InsertPost(actor);
        return Ok(result);
    }
    [HttpPost("insert-post-list")]
    public async Task<IActionResult> InsertDocumentList([FromBody] IList<IndexPosts> posts)
    {
        var result = await _postService.InsertDocumentList(posts);
        return Ok(result);
    }
    [HttpPost("update-post")]
    public async Task<IActionResult> UpdateDocumentByActor([FromBody] IndexPosts post)
    {
        var result = await _postService.UpdateDocumentByPost(post);
        return Ok(result);
    }
    [HttpGet("Get-total-count")]
    public async Task<IActionResult> GetTotalCount()
    {
        var result = await _postService.GetTotalCount();
        return Ok(result);
    }
    [HttpPost("delete-document")]
    public async Task<IActionResult> DeleteDocumentById(string Id)
    {
        var result = await _postService.DeleteDocumentById(Id);
        return Ok(result);
    }
    [HttpGet("delete-documents")]
    public async Task<IActionResult> DeleteDocuments([FromQuery] DeleteIndexPosts deleteIndePostss)
    {
        var result = await _postService.DeleteDocuments(deleteIndePostss);
        return Ok(result);
    }
    [HttpGet("get-posts-by-author-name")]
    public async Task<IActionResult> GetPostsByAuthorName([FromQuery] string authorName)
    {
        var result = await _postService.GetPostsByAuthorName(authorName);
        return Ok(result);
    }
}