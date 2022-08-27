using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class usuario_permiso
    {
        [DataMember]
        public string user_name { set; get; }

        [DataMember]
        public string id_permiso { set; get; }

        [DataMember]
        public Decimal valor_num { set; get; }

        [DataMember]
        public DateTime fecha_registro { set; get; }
    }
}