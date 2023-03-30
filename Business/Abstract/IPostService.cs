using Entities.Concrete;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IPostService
{
    Task InsertManyAsync();
    Task<ICollection<IndexPosts>> GetAllAsync();
    Task<ICollection<IndexPosts>> GetByNameWithTerm(string name);
    Task<ICollection<IndexPosts>> GetByNameWithMatch(string name);
    Task<ICollection<IndexPosts>> GetByNameWithMatchPhrase(string name);
    Task<ICollection<IndexPosts>> GetByNameAndDescriptionWithMultiMatch(string name);
    Task<ICollection<IndexPosts>> GetByNameWithMatchPhrasePrefix(string name);
    Task<ICollection<IndexPosts>> GetByNameWithWilcard(string name);
    Task<ICollection<IndexPosts>> GetByNameWithFuzzy(string name);
    Task<ICollection<IndexPosts>> SearchInAllFields(string name);
    Task<ICollection<IndexPosts>> GetByDescriptionMatch(string description);
    Task<ICollection<IndexPosts>> GetPostsAllCondition(string term);
    Task<bool> CreateIndex();
    Task<bool> InsertPost(IndexPosts post);
    Task<bool> InsertDocumentList(IList<IndexPosts> posts);
    Task<bool> UpdateDocumentByPost(IndexPosts post);
    Task<bool> DeleteDocumentById(string id);
    Task<bool> DeleteDocuments(DeleteIndexPosts post);
    Task<long> GetTotalCount();
    Task<IList<IndexPosts>> GetPostsByAuthorName(string authorName);
}

