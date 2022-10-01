using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries
{
    public class GetProductViewModel
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        [JsonIgnore]
        public List<KeyValuePair<string, string>> AttributeKey { get; set; }
        public Dictionary<string, string> Attributess { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
