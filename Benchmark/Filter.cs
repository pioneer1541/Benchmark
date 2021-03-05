using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    class Filter
    {
        public ArrayList recent_list { set; get; }




        public Filter (ArrayList recent_list)
        {
            this.recent_list = recent_list;
        }

        public IEnumerable<string> search_List (string key)
        {
            IEnumerable<string> result_list =
                from MyClass item in this.recent_list
                where item.Name.Contains(key)
                select item.get_Context_ToString() ;
            return result_list;
        }

        public IEnumerable<string> sort_ListZA()
        {
            IEnumerable<string> result_list =
                from MyClass item in this.recent_list
                orderby item.Name descending
                select item.get_Context_ToString();
            return result_list;
        }

        public IEnumerable<string> sort_ListAZ()
        {
            IEnumerable<string> result_list =
                from MyClass item in this.recent_list
                orderby item.Name
                select item.get_Context_ToString();
            return result_list;
        }
    }
}
