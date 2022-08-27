using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class inventario_fisico
    {

        [DataMember]
        public Guid id_inventario_fisico { set; get; }

        [DataMember]
        public Guid id_proveedor { set; get; }

        [DataMember]
        public string user_name { set; get; }

        [DataMember]
        public DateTime fecha_ini { set; get; }

        [DataMember]
        public string fecha_fin { set; get; }

        [DataMember]
        public DateTime fecha_registro { set; get; }
    }
}