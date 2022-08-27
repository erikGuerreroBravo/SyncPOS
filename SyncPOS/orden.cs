using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.orden")]
    public class orden : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_pedido;
        private long _num_pedido;
        private DateTime _fecha_pedido;
        private Guid _id_proveedor;
        private string _status_pedido;
        private short _no_dias;
        private DateTime? _fecha_autorizado;
        private string _plan;
        private short _anio;
        private short _mes;
        private DateTime _fecha_registro;
        private EntitySet<SyncPOS.orden_articulo> _orden_articulo;
        private EntityRef<proveedor> _proveedor;
        #endregion

        #region Constructor
        public orden()
        {
            this._orden_articulo = new EntitySet<SyncPOS.orden_articulo>(new Action<SyncPOS.orden_articulo>(this.attach_orden_articulo), new Action<SyncPOS.orden_articulo>(this.detach_orden_articulo));
            this._proveedor = new EntityRef<proveedor>();
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
                this.SendPropertyChanging();
                this._id_pedido = value;
                this.SendPropertyChanged(nameof(id_pedido));
            }
        }

        [Column(DbType = "BigInt NOT NULL", Storage = "_num_pedido")]
        public long num_pedido
        {
            get => this._num_pedido;
            set
            {
                if (this._num_pedido == value)
                    return;
                this.SendPropertyChanging();
                this._num_pedido = value;
                this.SendPropertyChanged(nameof(num_pedido));
            }
        }

        [Column(DbType = "DateTime NOT NULL", Storage = "_fecha_pedido")]
        public DateTime fecha_pedido
        {
            get => this._fecha_pedido;
            set
            {
                if (!(this._fecha_pedido != value))
                    return;
                this.SendPropertyChanging();
                this._fecha_pedido = value;
                this.SendPropertyChanged(nameof(fecha_pedido));
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

        [Column(CanBeNull = false, DbType = "VarChar(20) NOT NULL", Storage = "_status_pedido")]
        public string status_pedido
        {
            get => this._status_pedido;
            set
            {
                if (!(this._status_pedido != value))
                    return;
                this.SendPropertyChanging();
                this._status_pedido = value;
                this.SendPropertyChanged(nameof(status_pedido));
            }
        }

        [Column(DbType = "SmallInt NOT NULL", Storage = "_no_dias")]
        public short no_dias
        {
            get => this._no_dias;
            set
            {
                if ((int)this._no_dias == (int)value)
                    return;
                this.SendPropertyChanging();
                this._no_dias = value;
                this.SendPropertyChanged(nameof(no_dias));
            }
        }

        [Column(DbType = "DateTime", Storage = "_fecha_autorizado")]
        public DateTime? fecha_autorizado
        {
            get => this._fecha_autorizado;
            set
            {
                DateTime? fechaAutorizado = this._fecha_autorizado;
                DateTime? nullable = value;
                if ((fechaAutorizado.HasValue != nullable.HasValue ? 1 : (!fechaAutorizado.HasValue ? 0 : (fechaAutorizado.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : 0))) == 0)
                    return;
                this.SendPropertyChanging();
                this._fecha_autorizado = value;
                this.SendPropertyChanged(nameof(fecha_autorizado));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", Name = "[plan]", Storage = "_plan")]
        public string plan
        {
            get => this._plan;
            set
            {
                if (!(this._plan != value))
                    return;
                this.SendPropertyChanging();
                this._plan = value;
                this.SendPropertyChanged(nameof(plan));
            }
        }

        [Column(DbType = "SmallInt NOT NULL", Storage = "_anio")]
        public short anio
        {
            get => this._anio;
            set
            {
                if ((int)this._anio == (int)value)
                    return;
                this.SendPropertyChanging();
                this._anio = value;
                this.SendPropertyChanged(nameof(anio));
            }
        }

        [Column(DbType = "SmallInt NOT NULL", Storage = "_mes")]
        public short mes
        {
            get => this._mes;
            set
            {
                if ((int)this._mes == (int)value)
                    return;
                this.SendPropertyChanging();
                this._mes = value;
                this.SendPropertyChanged(nameof(mes));
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

        [Association(Name = "orden_orden_articulo", OtherKey = "id_pedido", Storage = "_orden_articulo", ThisKey = "id_pedido")]
        public EntitySet<SyncPOS.orden_articulo> orden_articulo
        {
            get => this._orden_articulo;
            set => this._orden_articulo.Assign((IEnumerable<SyncPOS.orden_articulo>)value);
        }

        [Association(IsForeignKey = true, Name = "proveedor_orden", OtherKey = "id_proveedor", Storage = "_proveedor", ThisKey = "id_proveedor")]
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
                    entity.orden.Remove(this);
                }
                this._proveedor.Entity = value;
                if (value != null)
                {
                    value.orden.Add(this);
                    this._id_proveedor = value.id_proveedor;
                }
                else
                    this._id_proveedor = new Guid();
                this.SendPropertyChanged(nameof(proveedor));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, orden.emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_orden_articulo(SyncPOS.orden_articulo entity)
        {
            this.SendPropertyChanging();
            entity.orden = this;
        }

        private void detach_orden_articulo(SyncPOS.orden_articulo entity)
        {
            this.SendPropertyChanging();
            entity.orden = (orden)null;
        }
        #endregion


    }
}