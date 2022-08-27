using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class compra
    {
        [DataMember]
        public string id_compra { set; get; }

        [DataMember]
        public string id_proveedor { set; get; }

        [DataMember]
        public string no_factura { set; get; }

        [DataMember]
        public string fecha_compra { set; get; }

        [DataMember]
        public string id_pedido { set; get; }

        [DataMember]
        public bool cancelada { set; get; }

        [DataMember]
        public DateTime fecha_cancelacion { set; get; }

        [DataMember]
        public short no_entrada { set; get; }

        [DataMember]
        public string observaciones { set; get; }
    }
}