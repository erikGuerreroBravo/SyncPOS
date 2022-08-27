using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace SyncPOS
{
    [Table(Name = "dbo.orden_articulo")]
    public class orden_articulo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_pedido;
        private short _no_articulo;
        private string _cod_barras;
        private string _cod_anexo;
        private Decimal _cantidad;
        private Decimal _precio_articulo;
        private Decimal _por_surtir;
        private Decimal _por_surtir_pzas;
        private DateTime _fecha_registro;
        private EntityRef<orden> _orden;
        private EntityRef<articulo> _articulo;
        private EntityRef<articulo> _articulo1;
        #endregion

        #region Constructor
        public orden_articulo()
        {
            this._orden = new EntityRef<orden>();
            this._articulo = new EntityRef<articulo>();
            this._articulo1 = new EntityRef<articulo>();
        }
        #endregion

        #region Metodos de Acción
        [Column(DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, Storage = "_id_pedido")]
        public Guid id_pedido
        {
            get => this._id_pedido;
            set
            {
                if (!(this._id_pedido != value))
                    return;
                if (this._orden.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._id_pedido = value;
                this.SendPropertyChanged(nameof(id_pedido));
            }
        }

        [Column(DbType = "SmallInt NOT NULL", IsPrimaryKey = true, Storage = "_no_articulo")]
        public short no_articulo
        {
            get => this._no_articulo;
            set
            {
                if ((int)this._no_articulo == (int)value)
                    return;
                this.SendPropertyChanging();
                this._no_articulo = value;
                this.SendPropertyChanged(nameof(no_articulo));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", Storage = "_cod_barras")]
        public string cod_barras
        {
            get => this._cod_barras;
            set
            {
                if (!(this._cod_barras != value))
                    return;
                if (this._articulo1.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._cod_barras = value;
                this.SendPropertyChanged(nameof(cod_barras));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", Storage = "_cod_anexo")]
        public string cod_anexo
        {
            get => this._cod_anexo;
            set
            {
                if (!(this._cod_anexo != value))
                    return;
                if (this._articulo.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._cod_anexo = value;
                this.SendPropertyChanged(nameof(cod_anexo));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_cantidad")]
        public Decimal cantidad
        {
            get => this._cantidad;
            set
            {
                if (!(this._cantidad != value))
                    return;
                this.SendPropertyChanging();
                this._cantidad = value;
                this.SendPropertyChanged(nameof(cantidad));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_precio_articulo")]
        public Decimal precio_articulo
        {
            get => this._precio_articulo;
            set
            {
                if (!(this._precio_articulo != value))
                    return;
                this.SendPropertyChanging();
                this._precio_articulo = value;
                this.SendPropertyChanged(nameof(precio_articulo));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_por_surtir")]
        public Decimal por_surtir
        {
            get => this._por_surtir;
            set
            {
                if (!(this._por_surtir != value))
                    return;
                this.SendPropertyChanging();
                this._por_surtir = value;
                this.SendPropertyChanged(nameof(por_surtir));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_por_surtir_pzas")]
        public Decimal por_surtir_pzas
        {
            get => this._por_surtir_pzas;
            set
            {
                if (!(this._por_surtir_pzas != value))
                    return;
                this.SendPropertyChanging();
                this._por_surtir_pzas = value;
                this.SendPropertyChanged(nameof(por_surtir_pzas));
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

        [Association(IsForeignKey = true, Name = "orden_orden_articulo", OtherKey = "id_pedido", Storage = "_orden", ThisKey = "id_pedido")]
        public orden orden
        {
            get => this._orden.Entity;
            set
            {
                orden entity = this._orden.Entity;
                if (entity == value && this._orden.HasLoadedOrAssignedValue)
                    return;
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._orden.Entity = (orden)null;
                    entity.orden_articulo.Remove(this);
                }
                this._orden.Entity = value;
                if (value != null)
                {
                    value.orden_articulo.Add(this);
                    this._id_pedido = value.id_pedido;
                }
                else
                    this._id_pedido = new Guid();
                this.SendPropertyChanged(nameof(orden));
            }
        }

        [Association(IsForeignKey = true, Name = "articulo_orden_articulo", OtherKey = "cod_barras", Storage = "_articulo", ThisKey = "cod_anexo")]
        public articulo articulo
        {
            get => this._articulo.Entity;
            set
            {
                articulo entity = this._articulo.Entity;
                if (entity == value && this._articulo.HasLoadedOrAssignedValue)
                    return;
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._articulo.Entity = (articulo)null;
                    entity.orden_articulo.Remove(this);
                }
                this._articulo.Entity = value;
                if (value != null)
                {
                    value.orden_articulo.Add(this);
                    this._cod_anexo = value.cod_barras;
                }
                else
                    this._cod_anexo = (string)null;
                this.SendPropertyChanged(nameof(articulo));
            }
        }

        [Association(IsForeignKey = true, Name = "articulo_orden_articulo1", OtherKey = "cod_barras", Storage = "_articulo1", ThisKey = "cod_barras")]
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
                    entity.orden_articulo1.Remove(this);
                }
                this._articulo1.Entity = value;
                if (value != null)
                {
                    value.orden_articulo1.Add(this);
                    this._cod_barras = value.cod_barras;
                }
                else
                    this._cod_barras = (string)null;
                this.SendPropertyChanged(nameof(articulo1));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, orden_articulo.emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


    }
}