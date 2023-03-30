using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public interface IElasticSearchBaseRepository<T> where T : class
{
    Task<T> GetAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> SearchAsync(Func<QueryContainerDescriptor<T>, QueryContainer> request);
    Task<IEnumerable<T>> SearchAsync(Func<SearchDescriptor<T>, ISearchRequest> selector);
    Task<ISearchResponse<T>> SearchAsync(Func<QueryContainerDescriptor<T>, QueryContainer> request, Func<AggregationContainerDescriptor<T>, IAggregationContainer> aggregationsSelector);
    QueryContainer SearchInAllFieldsAsync(string term);
    Task<bool> CreateIndexAsync();
    Task<bool> InsertAsync(T model);
    Task<bool> InsertManyAsync(IList<T> list);
    Task<bool> UpdateAsync(T model);
    Task<bool> UpdatePartAsync(T model, object part);
    Task<bool> DeleteByIdAsync(string id);
    Task<bool> DeleteByQueryAsync(Func<QueryContainerDescriptor<T>, QueryContainer> selector);
    Task<bool> ExistAsync(string id);
    Task<long> GetTotalCountAsync();
}
