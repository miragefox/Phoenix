using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phoenixw
{
    public class DemoList
    {
        private static readonly DemoList _instance = new DemoList();
        private DemoList() { }

        public static DemoList Instance
        {
            get { return _instance; }
        }

        public IList<Demo> IDs
        {
            get { return _messages; }
        }

        private IList<Demo> _messages = new List<Demo>{
            new Demo {Id = 1},
            new Demo {Id = 2},
            new Demo {Id = 3}
        };
    }
}