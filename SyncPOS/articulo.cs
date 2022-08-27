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
        #region Atributos
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
        #endregion

        #region Constructor
        public articulo()
        {
            this._articulo2 = new EntitySet<articulo>(new Action<articulo>(this.attach_articulo2), new Action<articulo>(this.detach_articulo2));
            this._compra_articulo = new EntitySet<SyncPOS.compra_articulo>(new Action<SyncPOS.compra_articulo>(this.attach_compra_articulo), new Action<SyncPOS.compra_articulo>(this.detach_compra_articulo));
            this._inventario_captura = new EntitySet<SyncPOS.inventario_captura>(new Action<SyncPOS.inventario_captura>(this.attach_inventario_captura), new Action<SyncPOS.inventario_captura>(this.detach_inventario_captura));
            this._orden_articulo = new EntitySet<SyncPOS.orden_articulo>(new Action<SyncPOS.orden_articulo>(this.attach_orden_articulo), new Action<SyncPOS.orden_articulo>(this.detach_orden_articulo));
            this._orden_articulo1 = new EntitySet<SyncPOS.orden_articulo>(new Action<SyncPOS.orden_articulo>(this.attach_orden_articulo1), new Action<SyncPOS.orden_articulo>(this.detach_orden_articulo1));
            this._articulo1 = new EntityRef<articulo>();
            this._proveedor = new EntityRef<proveedor>();
            this._unidad_medida = new EntityRef<unidad_medida>();
        }
        #endregion

        #region Metodos de Clase
        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", IsPrimaryKey = true, Storage = "_cod_barras")]
        public string cod_barras
        {
            get => this._cod_barras;
            set
            {
                if (!(this._cod_barras != value))
                    return;
                this.SendPropertyChanging();
                this._cod_barras = value;
                this.SendPropertyChanged(nameof(cod_barras));
            }
        }


        [Column(DbType = "VarChar(15)", Storage = "_cod_asociado")]
        public string cod_asociado
        {
            get => this._cod_asociado;
            set
            {
                if (!(this._cod_asociado != value))
                    return;
                if (this._articulo1.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._cod_asociado = value;
                this.SendPropertyChanged(nameof(cod_asociado));
            }
        }


        [Column(DbType = "BigInt NOT NULL", Storage = "_id_clasificacion")]
        public long id_clasificacion
        {
            get => this._id_clasificacion;
            set
            {
                if (this._id_clasificacion == value)
                    return;
                this.SendPropertyChanging();
                this._id_clasificacion = value;
                this.SendPropertyChanged(nameof(id_clasificacion));
            }
        }


        [Column(DbType = "VarChar(15)", Storage = "_cod_interno")]
        public string cod_interno
        {
            get => this._cod_interno;
            set
            {
                if (!(this._cod_interno != value))
                    return;
                this.SendPropertyChanging();
                this._cod_interno = value;
                this.SendPropertyChanged(nameof(cod_interno));
            }
        }


        [Column(CanBeNull = false, DbType = "VarChar(80) NOT NULL", Storage = "_descripcion")]
        public string descripcion
        {
            get => this._descripcion;
            set
            {
                if (!(this._descripcion != value))
                    return;
                this.SendPropertyChanging();
                this._descripcion = value;
                this.SendPropertyChanged(nameof(descripcion));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(30) NOT NULL", Storage = "_descripcion_corta")]
        public string descripcion_corta
        {
            get => this._descripcion_corta;
            set
            {
                if (!(this._descripcion_corta != value))
                    return;
                this.SendPropertyChanging();
                this._descripcion_corta = value;
                this.SendPropertyChanged(nameof(descripcion_corta));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_cantidad_um")]
        public Decimal cantidad_um
        {
            get => this._cantidad_um;
            set
            {
                if (!(this._cantidad_um != value))
                    return;
                this.SendPropertyChanging();
                this._cantidad_um = value;
                this.SendPropertyChanged(nameof(cantidad_um));
            }
        }


        [Column(DbType = "UniqueIdentifier NOT NULL", Storage = "_id_unidad")]
        public Guid id_unidad
        {
            get => this._id_unidad;
            set
            {
                if (!(this._id_unidad != value))
                    return;
                if (this._unidad_medida.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._id_unidad = value;
                this.SendPropertyChanged(nameof(id_unidad));
            }
        }


        [Column(DbType = "UniqueIdentifier NOT NULL", Storage = "_id_proveedor")]
        public Guid id_proveedor
        {
            get => this._id_proveedor;
            set
            {
                if (!(this._id_proveedor != value))
                    return;
                if (this._proveedor.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._id_proveedor = value;
                this.SendPropertyChanged(nameof(id_proveedor));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_precio_compra")]
        public Decimal precio_compra
        {
            get => this._precio_compra;
            set
            {
                if (!(this._precio_compra != value))
                    return;
                this.SendPropertyChanging();
                this._precio_compra = value;
                this.SendPropertyChanged(nameof(precio_compra));
            }
        }



        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_utilidad")]
        public Decimal utilidad
        {
            get => this._utilidad;
            set
            {
                if (!(this._utilidad != value))
                    return;
                this.SendPropertyChanging();
                this._utilidad = value;
                this.SendPropertyChanged(nameof(utilidad));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_precio_venta")]
        public Decimal precio_venta
        {
            get => this._precio_venta;
            set
            {
                if (!(this._precio_venta != value))
                    return;
                this.SendPropertyChanging();
                this._precio_venta = value;
                this.SendPropertyChanged(nameof(precio_venta));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(50) NOT NULL", Storage = "_tipo_articulo")]
        public string tipo_articulo
        {
            get => this._tipo_articulo;
            set
            {
                if (!(this._tipo_articulo != value))
                    return;
                this.SendPropertyChanging();
                this._tipo_articulo = value;
                this.SendPropertyChanged(nameof(tipo_articulo));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_stock")]
        public Decimal stock
        {
            get => this._stock;
            set
            {
                if (!(this._stock != value))
                    return;
                this.SendPropertyChanging();
                this._stock = value;
                this.SendPropertyChanged(nameof(stock));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_stock_min")]
        public Decimal stock_min
        {
            get => this._stock_min;
            set
            {
                if (!(this._stock_min != value))
                    return;
                this.SendPropertyChanging();
                this._stock_min = value;
                this.SendPropertyChanged(nameof(stock_min));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_stock_max")]
        public Decimal stock_max
        {
            get => this._stock_max;
            set
            {
                if (!(this._stock_max != value))
                    return;
                this.SendPropertyChanging();
                this._stock_max = value;
                this.SendPropertyChanged(nameof(stock_max));
            }
        }

        [Column(DbType = "Decimal(4,2) NOT NULL", Storage = "_iva")]
        public Decimal iva
        {
            get => this._iva;
            set
            {
                if (!(this._iva != value))
                    return;
                this.SendPropertyChanging();
                this._iva = value;
                this.SendPropertyChanged(nameof(iva));
            }
        }

        [Column(DbType = "DateTime", Storage = "_kit_fecha_ini")]
        public DateTime? kit_fecha_ini
        {
            get => this._kit_fecha_ini;
            set
            {
                DateTime? kitFechaIni = this._kit_fecha_ini;
                DateTime? nullable = value;
                if ((kitFechaIni.HasValue != nullable.HasValue ? 1 : (!kitFechaIni.HasValue ? 0 : (kitFechaIni.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : 0))) == 0)
                    return;
                this.SendPropertyChanging();
                this._kit_fecha_ini = value;
                this.SendPropertyChanged(nameof(kit_fecha_ini));
            }
        }

        [Column(DbType = "DateTime", Storage = "_kit_fecha_fin")]
        public DateTime? kit_fecha_fin
        {
            get => this._kit_fecha_fin;
            set
            {
                DateTime? kitFechaFin = this._kit_fecha_fin;
                DateTime? nullable = value;
                if ((kitFechaFin.HasValue != nullable.HasValue ? 1 : (!kitFechaFin.HasValue ? 0 : (kitFechaFin.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : 0))) == 0)
                    return;
                this.SendPropertyChanging();
                this._kit_fecha_fin = value;
                this.SendPropertyChanged(nameof(kit_fecha_fin));
            }
        }

        [Column(DbType = "Bit NOT NULL", Storage = "_articulo_disponible")]
        public bool articulo_disponible
        {
            get => this._articulo_disponible;
            set
            {
                if (this._articulo_disponible == value)
                    return;
                this.SendPropertyChanging();
                this._articulo_disponible = value;
                this.SendPropertyChanged(nameof(articulo_disponible));
            }
        }

        [Column(DbType = "Bit NOT NULL", Storage = "_kit")]
        public bool kit
        {
            get => this._kit;
            set
            {
                if (this._kit == value)
                    return;
                this.SendPropertyChanging();
                this._kit = value;
                this.SendPropertyChanged(nameof(kit));
            }
        }

        [Column(DbType = "DateTime NOT NULL", Storage = "_fecha_registro")]
        public DateTime fecha_registro
        {
            get => this._fecha_registro;
            set
            {
                if (!(this._fecha_registro != value))
                    return;
                this.SendPropertyChanging();
                this._fecha_registro = value;
                this.SendPropertyChanged(nameof(fecha_registro));
            }
        }

        [Column(DbType = "Bit NOT NULL", Storage = "_visible")]
        public bool visible
        {
            get => this._visible;
            set
            {
                if (this._visible == value)
                    return;
                this.SendPropertyChanging();
                this._visible = value;
                this.SendPropertyChanged(nameof(visible));
            }
        }

        [Column(DbType = "SmallInt NOT NULL", Storage = "_puntos")]
        public short puntos
        {
            get => this._puntos;
            set
            {
                if ((int)this._puntos == (int)value)
                    return;
                this.SendPropertyChanging();
                this._puntos = value;
                this.SendPropertyChanged(nameof(puntos));
            }
        }

        [Column(DbType = "DateTime NOT NULL", Storage = "_last_update_inventory")]
        public DateTime last_update_inventory
        {
            get => this._last_update_inventory;
            set
            {
                if (!(this._last_update_inventory != value))
                    return;
                this.SendPropertyChanging();
                this._last_update_inventory = value;
                this.SendPropertyChanged(nameof(last_update_inventory));
            }
        }

        [Association(Name = "articulo_articulo", OtherKey = "cod_asociado", Storage = "_articulo2", ThisKey = "cod_barras")]
        public EntitySet<articulo> articulo2
        {
            get => this._articulo2;
            set => this._articulo2.Assign((IEnumerable<articulo>)value);
        }

        [Association(Name = "articulo_compra_articulo", OtherKey = "cod_barras", Storage = "_compra_articulo", ThisKey = "cod_barras")]
        public EntitySet<SyncPOS.compra_articulo> compra_articulo
        {
            get => this._compra_articulo;
            set => this._compra_articulo.Assign((IEnumerable<SyncPOS.compra_articulo>)value);
        }

        [Association(Name = "articulo_inventario_captura", OtherKey = "cod_barras", Storage = "_inventario_captura", ThisKey = "cod_barras")]
        public EntitySet<SyncPOS.inventario_captura> inventario_captura
        {
            get => this._inventario_captura;
            set => this._inventario_captura.Assign((IEnumerable<SyncPOS.inventario_captura>)value);
        }

        [Association(Name = "articulo_orden_articulo", OtherKey = "cod_anexo", Storage = "_orden_articulo", ThisKey = "cod_barras")]
        public EntitySet<SyncPOS.orden_articulo> orden_articulo
        {
            get => this._orden_articulo;
            set => this._orden_articulo.Assign((IEnumerable<SyncPOS.orden_articulo>)value);
        }

        [Association(Name = "articulo_orden_articulo1", OtherKey = "cod_barras", Storage = "_orden_articulo1", ThisKey = "cod_barras")]
        public EntitySet<SyncPOS.orden_articulo> orden_articulo1
        {
            get => this._orden_articulo1;
            set => this._orden_articulo1.Assign((IEnumerable<SyncPOS.orden_articulo>)value);
        }

        [Association(IsForeignKey = true, Name = "articulo_articulo", OtherKey = "cod_barras", Storage = "_articulo1", ThisKey = "cod_asociado")]
        public articulo articulo1
        {
            get => this._articulo1.Entity;
            set
            {
                articulo entity = this._articulo1.Entity;
                if (entity == value && this._articulo1.HasLoadedOrAssignedValue)
                    return;
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._articulo1.Entity = (articulo)null;
                    entity.articulo2.Remove(this);
                }
                this._articulo1.Entity = value;
                if (value != null)
                {
                    value.articulo2.Add(this);
                    this._cod_asociado = value.cod_barras;
                }
                else
                    this._cod_asociado = (string)null;
                this.SendPropertyChanged(nameof(articulo1));
            }
        }

        [Association(IsForeignKey = true, Name = "proveedor_articulo", OtherKey = "id_proveedor", Storage = "_proveedor", ThisKey = "id_proveedor")]
        public proveedor proveedor
        {
            get => this._proveedor.Entity;
            set
            {
                proveedor entity = this._proveedor.Entity;
                if (entity == value && this._proveedor.HasLoadedOrAssignedValue)
                    return;
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._proveedor.Entity = (proveedor)null;
                    entity.articulo.Remove(this);
                }
                this._proveedor.Entity = value;
                if (value != null)
                {
                    value.articulo.Add(this);
                    this._id_proveedor = value.id_proveedor;
                }
                else
                    this._id_proveedor = new Guid();
                this.SendPropertyChanged(nameof(proveedor));
            }
        }

        [Association(IsForeignKey = true, Name = "unidad_medida_articulo", OtherKey = "id_unidad", Storage = "_unidad_medida", ThisKey = "id_unidad")]
        public unidad_medida unidad_medida
        {
            get => this._unidad_medida.Entity;
            set
            {
                unidad_medida entity = this._unidad_medida.Entity;
                if (entity == value && this._unidad_medida.HasLoadedOrAssignedValue)
                    return;
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._unidad_medida.Entity = (unidad_medida)null;
                    entity.articulo.Remove(this);
                }
                this._unidad_medida.Entity = value;
                if (value != null)
                {
                    value.articulo.Add(this);
                    this._id_unidad = value.id_unidad;
                }
                else
                    this._id_unidad = new Guid();
                this.SendPropertyChanged(nameof(unidad_medida));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, articulo.emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_articulo2(articulo entity)
        {
            this.SendPropertyChanging();
            entity.articulo1 = this;
        }

        private void detach_articulo2(articulo entity)
        {
            this.SendPropertyChanging();
            entity.articulo1 = (articulo)null;
        }

        private void attach_compra_articulo(SyncPOS.compra_articulo entity)
        {
            this.SendPropertyChanging();
            entity.articulo = this;
        }

        private void detach_compra_articulo(SyncPOS.compra_articulo entity)
        {
            this.SendPropertyChanging();
            entity.articulo = (articulo)null;
        }

        private void attach_inventario_captura(SyncPOS.inventario_captura entity)
        {
            this.SendPropertyChanging();
            entity.articulo = this;
        }

        private void detach_inventario_captura(SyncPOS.inventario_captura entity)
        {
            this.SendPropertyChanging();
            entity.articulo = (articulo)null;
        }

        private void attach_orden_articulo(SyncPOS.orden_articulo entity)
        {
            this.SendPropertyChanging();
            entity.articulo = this;
        }

        private void detach_orden_articulo(SyncPOS.orden_articulo entity)
        {
            this.SendPropertyChanging();
            entity.articulo = (articulo)null;
        }

        private void attach_orden_articulo1(SyncPOS.orden_articulo entity)
        {
            this.SendPropertyChanging();
            entity.articulo1 = this;
        }

        private void detach_orden_articulo1(SyncPOS.orden_articulo entity)
        {
            this.SendPropertyChanging();
            entity.articulo1 = (articulo)null;
        }

        #endregion



    }
}