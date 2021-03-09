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
        public ArrayList recent_list { set; get; } //Defined to store recent_list for filting list. 




        public Filter (ArrayList recent_list) //construction method
        {
            this.recent_list = recent_list;
        }

        public IEnumerable<string> search_List(string key) //Acquire a new list that results from the object name that contains the keyword.
        {
            try
            {
                IEnumerable<string> result_list =
                from MyClass item in this.recent_list
                where item.Name.Contains(key)
                select item.context;
                return result_list;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public IEnumerable<string> sort_ListZA() //Sorting recent list by descending order.
        {
            try
            {
                IEnumerable<string> result_list =
                from MyClass item in this.recent_list
                orderby item.Name descending
                select item.context;
                return result_list;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<string> sort_ListAZ() //Sorting recent list by ascending order.
        {
            try
            {
                IEnumerable<string> result_list =
                from MyClass item in this.recent_list
                orderby item.Name
                select item.context;
                return result_list;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
