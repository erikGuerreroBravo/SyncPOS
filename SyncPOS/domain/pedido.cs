using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class pedido
    {
        [DataMember]
        public Guid id_pedido { set; get; }

        [DataMember]
        public long num_pedido { set; get; }

        [DataMember]
        public DateTime fecha_pedido { set; get; }

        [DataMember]
        public Guid id_proveedor { set; get; }

        [DataMember]
        public string status_pedido { set; get; }

        [DataMember]
        public DateTime fecha_registro { set; get; }
    }
}