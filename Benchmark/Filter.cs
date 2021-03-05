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


    }
}
