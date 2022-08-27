using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class usuario
    {
        [DataMember]
        public string user_name { set; get; }

        [DataMember]
        public string password { set; get; }

        [DataMember]
        public string tipo_usuario { set; get; }

        [DataMember]
        public bool enable { set; get; }

        [DataMember]
        public DateTime fecha_registro { set; get; }
    }
}