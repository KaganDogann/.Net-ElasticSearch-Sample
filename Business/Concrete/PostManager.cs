using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.Concrete.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class PostManager : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostManager(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task InsertManyAsync()
    {
        await _postRepository.InsertManyAsync(NestExtensions.GetSampleData());
    }

    public async Task<ICollection<IndexPosts>> GetAllAsync()
    {
        var response = await _postRepository.GetAllAsync();
        return response.ToList();
    }

    public async Task<ICollection<IndexPosts>> GetByNameWithMatch(string name)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().Match(q => q.Field(t => t.PostName).Query(name));
        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }

    public async Task<ICollection<IndexPosts>> GetByNameWithTerm(string name)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().Term(q => q.Field(t => t.PostName).Value(name).CaseInsensitive().Boost(6.0));
        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }

    public async Task<ICollection<IndexPosts>> GetByNameWithMatchPhrase(string name)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().MatchPhrase(q => q.Field(t => t.PostName).Query(name));
        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }

    public async Task<ICollection<IndexPosts>> GetByNameAndDescriptionWithMultiMatch(string name)
    {
        var query = new QueryContainerDescriptor<IndexPosts>()
            .MultiMatch(q => q
                .Fields(t => t
                  .Field(y => y.PostName)
                  .Field(t => t.PostDescription))
              .Query(name));
        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }

    public async Task<ICollection<IndexPosts>> GetByNameWithMatchPhrasePrefix(string name)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().MatchPhrasePrefix(q => q.Field(t => t.PostName).Query(name));
        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }

    public async Task<ICollection<IndexPosts>> GetByNameWithWilcard(string name)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().Wildcard(q => q.Field(t => t.PostName).Value($"*{name}*").CaseInsensitive());
        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }

    public async Task<ICollection<IndexPosts>> GetByNameWithFuzzy(string name)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().Fuzzy(q => q.Field(t => t.PostName).Value(name));
        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }

    public async Task<ICollection<IndexPosts>> SearchInAllFields(string name)
    {
        var query = NestExtensions.BuildMultiMatchQuery<IndexPosts>(name);
        var result = await _postRepository.SearchAsync(_ => query);

        return result.ToList();
    }

    public async Task<ICollection<IndexPosts>> GetByDescriptionMatch(string description)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().Match(q=>q.Field(t=>t.PostDescription).Query(description));
        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }
    public async Task<ICollection<IndexPosts>> GetPostsAllCondition(string term)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().Wildcard(q => q.Field(t => t.PostName).Value($"*{term}*"));
        query = query || new QueryContainerDescriptor<IndexPosts>().Wildcard(q => q.Field(term => term.PostDescription).Value($"*{term}*"));

        var response = await _postRepository.SearchAsync(_ => query);
        return response.ToList();
    }
    public async Task<bool> CreateIndex()
    {
        return await _postRepository.CreateIndexAsync();
        
    }
    public async Task<bool> InsertPost(IndexPosts post)
    {
        return await _postRepository.InsertAsync(post);
    }

    public async Task<bool> InsertDocumentList(IList<IndexPosts> posts)
    {
        return await _postRepository.InsertManyAsync(posts);
    }

    public async Task<bool> UpdateDocumentByPost(IndexPosts post)
    {
        return await _postRepository.UpdateAsync(post);
    }

    public async Task<bool> DeleteDocumentById(string Id)
    {
        return await _postRepository.DeleteByIdAsync(Id);
    }

    public async Task<bool> DeleteDocuments(DeleteIndexPosts post)
    {
        QueryContainer query = new QueryContainerDescriptor<IndexPosts>();

        if (!String.IsNullOrEmpty(post.PostName))
        {
            query = query || new QueryContainerDescriptor<IndexPosts>().Match(q => q.Field(t => t.PostName).Query(post.PostName));
        }
        if (post.PostDescription != default)
        {
            query = query || new QueryContainerDescriptor<IndexPosts>().Term(q => q.PostDescription, post.PostDescription);
        }

        if (post.CreatedDate != default)
        {
            query = query || new QueryContainerDescriptor<IndexPosts>().DateRange(q => q.Field(t => t.CreatedDate)
            .GreaterThanOrEquals(post.CreatedDate)
            .LessThanOrEquals(post.CreatedDate)
            .TimeZone("+00:00"));
        }
        return await _postRepository.DeleteByQueryAsync(_ => query);
    }
    public async Task<long> GetTotalCount()
    {
        return await _postRepository.GetTotalCountAsync();
    }

    public async Task<IList<IndexPosts>> GetPostsByAuthorName(string authorName)
    {
        var query = new QueryContainerDescriptor<IndexPosts>().Match(m=>m.Field(f=>f.IndexAuthor.AuthorName).Query(authorName));
        var response = await _postRepository.SearchAsync(_ => query);

        return response.ToList();
    }
}
