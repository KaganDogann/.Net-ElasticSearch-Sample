using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class IndexPosts : ElasticBaseIndex
{
    public string PostName { get; set; }
    public string PostDescription { get; set; }
    public IndexAuthors IndexAuthor { get; set; }
    public DateTime CreatedDate { get; set; }

}
