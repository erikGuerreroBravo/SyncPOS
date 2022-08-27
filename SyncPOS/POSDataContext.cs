using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace SyncPOS
{
    [Database(Name = "pos_admin")]
    public class POSDataContext: DataContext
    {
        private static MappingSource mappingSource = (MappingSource)new AttributeMappingSource();
        public POSDataContext():base()
        {

        }
    }
}