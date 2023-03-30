using Core;
using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Nest;

namespace DataAccess.Concrete;

public class PostRepository : ElasticSearchBaseRepository<IndexPosts>, IPostRepository
{
    public PostRepository(IElasticClient elasticClient) : base(elasticClient)
    {
    }
    public override string IndexName { get; } = "indexposts";

}
