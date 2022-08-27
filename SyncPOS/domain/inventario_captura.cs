using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class inventario_captura
    {
        [DataMember]
        public string id_captura { set; get; }

        [DataMember]
        public string id_inventario_fisico { set; get; }

        [DataMember]
        public string num_captura { set; get; }

        [DataMember]
        public string cod_barras { set; get; }

        [DataMember]
        public string fecha_captura { set; get; }

        [DataMember]
        public string cant_cja { set; get; }

        [DataMember]
        public string cant_pza { set; get; }
    }
}