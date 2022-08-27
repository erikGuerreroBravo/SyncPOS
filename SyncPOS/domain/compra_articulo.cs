using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class compra_articulo
    {

        [DataMember]
        public string id_compra { set; get; }

        [DataMember]
        public string cod_barras { set; get; }

        [DataMember]
        public string num_articulo { set; get; }

        [DataMember]
        public string cant_cja { set; get; }

        [DataMember]
        public string cant_pza { set; get; }

        [DataMember]
        public string precio_compra { set; get; }

        [DataMember]
        public string no_captura { set; get; }

        [DataMember]
        public string no_entrega { set; get; }
    }
}