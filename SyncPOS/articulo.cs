using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.articulo")]
    public class articulo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private string _cod_barras;
        private string _cod_asociado;
        private long _id_clasificacion;
        private string _cod_interno;
        private string _descripcion;
        private string _descripcion_corta;
        private Decimal _cantidad_um;
        private Guid _id_unidad;
        private Guid _id_proveedor;
        private Decimal _precio_compra;
        private Decimal _utilidad;
        private Decimal _precio_venta;
        private string _tipo_articulo;
        private Decimal _stock;
        private Decimal _stock_min;
        private Decimal _stock_max;
        private Decimal _iva;
        private DateTime? _kit_fecha_ini;
        private DateTime? _kit_fecha_fin;
        private bool _articulo_disponible;
        private bool _kit;
        private DateTime _fecha_registro;
        private bool _visible;
        private short _puntos;
        private DateTime _last_update_inventory;
        private EntitySet<articulo> _articulo2;
        private EntitySet<SyncPOS.compra_articulo> _compra_articulo;
        private EntitySet<SyncPOS.inventario_captura> _inventario_captura;
        private EntitySet<SyncPOS.orden_articulo> _orden_articulo;
        private EntitySet<SyncPOS.orden_articulo> _orden_articulo1;
        private EntityRef<articulo> _articulo1;
        private EntityRef<proveedor> _proveedor;
        private EntityRef<unidad_medida> _unidad_medida;

    }
}