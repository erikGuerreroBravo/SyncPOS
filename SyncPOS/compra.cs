using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.compra")]
    public class compra : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region  atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_compra;
        private Guid? _id_proveedor;
        private string _no_factura;
        private DateTime _fecha_compra;
        private Guid? _id_pedido;
        private bool _cancelada;
        private DateTime? _fecha_cancelacion;
        private short _no_entrada;
        private string _observaciones;
        private EntitySet<SyncPOS.compra_articulo> _compra_articulo;
        private EntityRef<proveedor> _proveedor;
        #endregion

        #region Constructor
        public compra()
        {
            this._compra_articulo = new EntitySet<SyncPOS.compra_articulo>(new Action<SyncPOS.compra_articulo>(this.attach_compra_articulo), new Action<SyncPOS.compra_articulo>(this.detach_compra_articulo));
            this._proveedor = new EntityRef<proveedor>();
        }
        #endregion


        #region Metodos
        [Column(DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, Storage = "_id_compra")]
        public Guid id_compra
        {
            get => this._id_compra;
            set
            {
                if (!(this._id_compra != value))
                    return;
                this.SendPropertyChanging();
                this._id_compra = value;
                this.SendPropertyChanged(nameof(id_compra));
            }
        }

        [Column(DbType = "UniqueIdentifier", Storage = "_id_proveedor")]
        public Guid? id_proveedor
        {
            get => this._id_proveedor;
            set
            {
                Guid? idProveedor = this._id_proveedor;
                Guid? nullable = value;
                if ((idProveedor.HasValue != nullable.HasValue ? 1 : (!idProveedor.HasValue ? 0 : (idProveedor.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : 0))) == 0)
                    return;
                if (this._proveedor.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._id_proveedor = value;
                this.SendPropertyChanged(nameof(id_proveedor));
            }
        }

        [Column(DbType = "VarChar(20)", Storage = "_no_factura")]
        public string no_factura
        {
            get => this._no_factura;
            set
            {
                if (!(this._no_factura != value))
                    return;
                this.SendPropertyChanging();
                this._no_factura = value;
                this.SendPropertyChanged(nameof(no_factura));
            }
        }

        [Column(DbType = "DateTime NOT NULL", Storage = "_fecha_compra")]
        public DateTime fecha_compra
        {
            get => this._fecha_compra;
            set
            {
                if (!(this._fecha_compra != value))
                    return;
                this.SendPropertyChanging();
                this._fecha_compra = value;
                this.SendPropertyChanged(nameof(fecha_compra));
            }
        }

        [Column(DbType = "UniqueIdentifier", Storage = "_id_pedido")]
        public Guid? id_pedido
        {
            get => this._id_pedido;
            set
            {
                Guid? idPedido = this._id_pedido;
                Guid? nullable = value;
                if ((idPedido.HasValue != nullable.HasValue ? 1 : (!idPedido.HasValue ? 0 : (idPedido.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : 0))) == 0)
                    return;
                this.SendPropertyChanging();
                this._id_pedido = value;
                this.SendPropertyChanged(nameof(id_pedido));
            }
        }

        [Column(DbType = "Bit NOT NULL", Storage = "_cancelada")]
        public bool cancelada
        {
            get => this._cancelada;
            set
            {
                if (this._cancelada == value)
                    return;
                this.SendPropertyChanging();
                this._cancelada = value;
                this.SendPropertyChanged(nameof(cancelada));
            }
        }

        [Column(DbType = "DateTime", Storage = "_fecha_cancelacion")]
        public DateTime? fecha_cancelacion
        {
            get => this._fecha_cancelacion;
            set
            {
                DateTime? fechaCancelacion = this._fecha_cancelacion;
                DateTime? nullable = value;
                if ((fechaCancelacion.HasValue != nullable.HasValue ? 1 : (!fechaCancelacion.HasValue ? 0 : (fechaCancelacion.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : 0))) == 0)
                    return;
                this.SendPropertyChanging();
                this._fecha_cancelacion = value;
                this.SendPropertyChanged(nameof(fecha_cancelacion));
            }
        }

        [Column(DbType = "SmallInt NOT NULL", Storage = "_no_entrada")]
        public short no_entrada
        {
            get => this._no_entrada;
            set
            {
                if ((int)this._no_entrada == (int)value)
                    return;
                this.SendPropertyChanging();
                this._no_entrada = value;
                this.SendPropertyChanged(nameof(no_entrada));
            }
        }

        [Column(DbType = "VarChar(100)", Storage = "_observaciones")]
        public string observaciones
        {
            get => this._observaciones;
            set
            {
                if (!(this._observaciones != value))
                    return;
                this.SendPropertyChanging();
                this._observaciones = value;
                this.SendPropertyChanged(nameof(observaciones));
            }
        }

        [Association(Name = "compra_compra_articulo", OtherKey = "id_compra", Storage = "_compra_articulo", ThisKey = "id_compra")]
        public EntitySet<SyncPOS.compra_articulo> compra_articulo
        {
            get => this._compra_articulo;
            set => this._compra_articulo.Assign((IEnumerable<SyncPOS.compra_articulo>)value);
        }

        [Association(IsForeignKey = true, Name = "proveedor_compra", OtherKey = "id_proveedor", Storage = "_proveedor", ThisKey = "id_proveedor")]
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
                    entity.compra.Remove(this);
                }
                this._proveedor.Entity = value;
                if (value != null)
                {
                    value.compra.Add(this);
                    this._id_proveedor = new Guid?(value.id_proveedor);
                }
                else
                    this._id_proveedor = new Guid?();
                this.SendPropertyChanged(nameof(proveedor));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, compra.emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_compra_articulo(SyncPOS.compra_articulo entity)
        {
            this.SendPropertyChanging();
            entity.compra = this;
        }

        private void detach_compra_articulo(SyncPOS.compra_articulo entity)
        {
            this.SendPropertyChanging();
            entity.compra = (compra)null;
        }
        #endregion
    }
}