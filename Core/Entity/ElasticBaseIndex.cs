using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity;

public class ElasticBaseIndex
{
    public string Id { get; set; }
    public DateTime? UpdateTime { get; set; }
}
