using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class proveedor
    {
        [DataMember]
        public Guid id_proveedor { set; get; }

        [DataMember]
        public string rfc { set; get; }

        [DataMember]
        public string razon_social { set; get; }

        [DataMember]
        public string estatus { set; get; }

        [DataMember]
        public DateTime last_change_datetime { set; get; }
    }
}