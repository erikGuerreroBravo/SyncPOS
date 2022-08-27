using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SyncPOS.domain
{
    [DataContract]
    public class articulo
    {
        [DataMember]
        public string cod_barras { set; get; }

        [DataMember]
        public string cod_asociado { set; get; }

        [DataMember]
        public long id_clasificacion { set; get; }

        [DataMember]
        public string cod_interno { set; get; }

        [DataMember]
        public string descripcion { set; get; }

        [DataMember]
        public string descripcion_corta { set; get; }

        [DataMember]
        public Decimal cantidad_um { set; get; }

        [DataMember]
        public Guid id_unidad { set; get; }

        [DataMember]
        public Guid id_proveedor { set; get; }

        [DataMember]
        public Decimal precio_compra { set; get; }

        [DataMember]
        public Decimal utilidad { set; get; }

        [DataMember]
        public Decimal precio_venta { set; get; }

        [DataMember]
        public string tipo_articulo { set; get; }

        [DataMember]
        public Decimal stock { set; get; }

        [DataMember]
        public Decimal stock_min { set; get; }

        [DataMember]
        public Decimal stock_max { set; get; }

        [DataMember]
        public Decimal iva { set; get; }

        [DataMember]
        public DateTime kit_fecha_ini { set; get; }

        [DataMember]
        public DateTime kit_fecha_fin { set; get; }

        [DataMember]
        public bool articulo_disponible { set; get; }

        [DataMember]
        public bool kit { set; get; }

        [DataMember]
        public DateTime fecha_registro { set; get; }

        [DataMember]
        public bool visible { set; get; }

        [DataMember]
        public short puntos { set; get; }

        [DataMember]
        public DateTime last_update_inventory { set; get; }
    }
}