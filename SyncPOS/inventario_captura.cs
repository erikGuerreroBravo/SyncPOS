using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.inventario_captura")]
    public class inventario_captura : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_captura;
        private Guid _id_inventario_fisico;
        private long _num_captura;
        private string _cod_barras;
        private DateTime _fecha_captura;
        private Decimal _cant_cja;
        private Decimal _cant_pza;
        private EntityRef<articulo> _articulo;
        private EntityRef<inventario_fisico> _inventario_fisico;
        #endregion

        #region Constructor
        public inventario_captura()
        {
            this._articulo = new EntityRef<articulo>();
            this._inventario_fisico = new EntityRef<inventario_fisico>();
        }
        #endregion

        #region Metodos de Acción
        [Column(DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, Storage = "_id_captura")]
        public Guid id_captura
        {
            get => this._id_captura;
            set
            {
                if (!(this._id_captura != value))
                    return;
                this.SendPropertyChanging();
                this._id_captura = value;
                this.SendPropertyChanged(nameof(id_captura));
            }
        }

        [Column(DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, Storage = "_id_inventario_fisico")]
        public Guid id_inventario_fisico
        {
            get => this._id_inventario_fisico;
            set
            {
                if (!(this._id_inventario_fisico != value))
                    return;
                if (this._inventario_fisico.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._id_inventario_fisico = value;
                this.SendPropertyChanged(nameof(id_inventario_fisico));
            }
        }

        [Column(DbType = "BigInt NOT NULL", IsPrimaryKey = true, Storage = "_num_captura")]
        public long num_captura
        {
            get => this._num_captura;
            set
            {
                if (this._num_captura == value)
                    return;
                this.SendPropertyChanging();
                this._num_captura = value;
                this.SendPropertyChanged(nameof(num_captura));
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
                if (this._articulo.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._cod_barras = value;
                this.SendPropertyChanged(nameof(cod_barras));
            }
        }

        [Column(DbType = "DateTime NOT NULL", Storage = "_fecha_captura")]
        public DateTime fecha_captura
        {
            get => this._fecha_captura;
            set
            {
                if (!(this._fecha_captura != value))
                    return;
                this.SendPropertyChanging();
                this._fecha_captura = value;
                this.SendPropertyChanged(nameof(fecha_captura));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_cant_cja")]
        public Decimal cant_cja
        {
            get => this._cant_cja;
            set
            {
                if (!(this._cant_cja != value))
                    return;
                this.SendPropertyChanging();
                this._cant_cja = value;
                this.SendPropertyChanged(nameof(cant_cja));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_cant_pza")]
        public Decimal cant_pza
        {
            get => this._cant_pza;
            set
            {
                if (!(this._cant_pza != value))
                    return;
                this.SendPropertyChanging();
                this._cant_pza = value;
                this.SendPropertyChanged(nameof(cant_pza));
            }
        }

        [Association(IsForeignKey = true, Name = "articulo_inventario_captura", OtherKey = "cod_barras", Storage = "_articulo", ThisKey = "cod_barras")]
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
                    entity.inventario_captura.Remove(this);
                }
                this._articulo.Entity = value;
                if (value != null)
                {
                    value.inventario_captura.Add(this);
                    this._cod_barras = value.cod_barras;
                }
                else
                    this._cod_barras = (string)null;
                this.SendPropertyChanged(nameof(articulo));
            }
        }

        [Association(IsForeignKey = true, Name = "inventario_fisico_inventario_captura", OtherKey = "id_inventario_fisico", Storage = "_inventario_fisico", ThisKey = "id_inventario_fisico")]
        public inventario_fisico inventario_fisico
        {
            get => this._inventario_fisico.Entity;
            set
            {
                inventario_fisico entity = this._inventario_fisico.Entity;
                if (entity == value && this._inventario_fisico.HasLoadedOrAssignedValue)
                    return;
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._inventario_fisico.Entity = (inventario_fisico)null;
                    entity.inventario_captura.Remove(this);
                }
                this._inventario_fisico.Entity = value;
                if (value != null)
                {
                    value.inventario_captura.Add(this);
                    this._id_inventario_fisico = value.id_inventario_fisico;
                }
                else
                    this._id_inventario_fisico = new Guid();
                this.SendPropertyChanged(nameof(inventario_fisico));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, inventario_captura.emptyChangingEventArgs);
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