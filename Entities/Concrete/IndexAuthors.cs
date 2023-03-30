using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class IndexAuthors : ElasticBaseIndex
    {
        public string AuthorName { get; set; }
    }
}
