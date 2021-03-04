using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    class Filter
    {
        public int index { get; set; }
        public MyClass image { get; set; }


        public Filter (int index,MyClass image)
        {
            this.index = index;
            this.image = image;
        }

    }
}
