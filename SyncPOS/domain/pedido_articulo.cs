using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class pedido_articulo
    {
        [DataMember]
        public Guid id_pedido { set; get; }

        [DataMember]
        public short no_articulo { set; get; }

        [DataMember]
        public string cod_barras { set; get; }

        [DataMember]
        public string cod_anexo { set; get; }

        [DataMember]
        public Decimal cantidad { set; get; }

        [DataMember]
        public Decimal precio_articulo { set; get; }

        [DataMember]
        public Decimal por_surtir { set; get; }

        [DataMember]
        public Decimal por_surtir_pzas { set; get; }

        [DataMember]
        public DateTime fecha_registro { set; get; }
    }
}