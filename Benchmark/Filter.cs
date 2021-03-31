using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Benchmark
{
    public class Filter
    {
        public ArrayList Recent_List { set; get; } //Defined to store Recent_List for filting list. 




        public Filter(ArrayList Recent_List) //construction method
        {
            this.Recent_List = Recent_List;
        }

        public ArrayList Search_List(string key) //Acquire a new list that results from the object name that contains the keyword.
        {
            try
            {
                IEnumerable<string> result_list =
                from MyClass item in this.Recent_List
                where item.Name.Contains(key)
                select item.context;
                ArrayList finial_List = new ArrayList();
                foreach (var i in result_list)
                {
                    finial_List.Add(i);
                }

                return finial_List;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ArrayList Sort_ListZA() //Sorting recent list by descending order.
        {
            try
            {
                IEnumerable<string> result_list =
                from MyClass item in this.Recent_List
                orderby item.Name descending
                select item.context;

                ArrayList finial_List = new ArrayList();
                foreach (var i in result_list)
                {
                    finial_List.Add(i);
                }

                return finial_List;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ArrayList Sort_ListAZ() //Sorting recent list by ascending order.
        {
            try
            {
                IEnumerable<string> result_list =
                from MyClass item in this.Recent_List
                orderby item.Name
                select item.context;
                ArrayList finial_List = new ArrayList();
                foreach (var i in result_list)
                {
                    finial_List.Add(i);
                }

                return finial_List;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
