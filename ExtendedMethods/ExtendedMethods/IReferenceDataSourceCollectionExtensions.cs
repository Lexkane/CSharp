using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedMethods
{
    public static class IReferenceDataSourceCollectionExtensions
    {

        public static IEnumerable<ReferenceDataItem> GetAllItemsByCode(this IReferenceDataSource [] sources, string code)
        {
            var items = new List<ReferenceDataItem>();
            foreach (var source in sources)
            {
                items.AddRange(source.GetItemsByCode(code));
            }
            return items;
        }


        public static IEnumerable<ReferenceDataItem> GetAllItemsByCode(this IEnumerable<IReferenceDataSource> sources,string code)
        {
            return sources.SelectMany(x => x.GetItemsByCode(code));
        }

    }


   
}
