using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRest.Model
{
    public class Test2 : ITest
    {
        public string v1 {
            get {                return "bbb";                    }
            set { }
        }
        public int v2 { get; set; }
    }
}
