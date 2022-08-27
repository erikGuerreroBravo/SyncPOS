using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class unidad_medida
    {
        [DataMember]
        public Guid id_unidad { set; get; }

        [DataMember]
        public string descripcion { set; get; }

        [DataMember]
        public DateTime fecha_registro { set; get; }
    }
}