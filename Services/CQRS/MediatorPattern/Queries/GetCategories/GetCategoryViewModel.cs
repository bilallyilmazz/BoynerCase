using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CQRS.MediatorPattern.Queries.GetCategories
{
    public class GetCategoryViewModel
    {
        public GetCategoryViewModel()
        {
            CategoryAttributes = new Dictionary<string, List<string>>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, List<string>> CategoryAttributes { get; set; }
    }
}
