using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Phoenixw
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DemoRESTService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DemoRESTService.svc or DemoRESTService.svc.cs at the Solution Explorer and start debugging.
    public class DemoRESTService : IDemoRESTService
    {
        public Demo GetDemoById(string Id)
        {
            return DemoList.Instance.IDs[int.Parse(Id)];
        }

        public IList<Demo> GetDemoList()
        {
            return DemoList.Instance.IDs;
        }
    }
}
