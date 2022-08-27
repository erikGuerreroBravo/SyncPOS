using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.compra_articulo")]
    public class compra_articulo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_compra;
        private string _cod_barras;
        private short _num_articulo;
        private Decimal _cant_cja;
        private Decimal _cant_pza;
        private Decimal _precio_compra;
        private short _no_captura;
        private Decimal _no_entrega;
        private EntityRef<articulo> _articulo;
        private EntityRef<compra> _compra;
        #endregion

        #region Constructor
        public compra_articulo()
        {
            this._articulo = new EntityRef<articulo>();
            this._compra = new EntityRef<compra>();
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
                if (this._compra.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._id_compra = value;
                this.SendPropertyChanged(nameof(id_compra));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", IsPrimaryKey = true, Storage = "_cod_barras")]
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

        [Column(DbType = "SmallInt NOT NULL", IsPrimaryKey = true, Storage = "_num_articulo")]
        public short num_articulo
        {
            get => this._num_articulo;
            set
            {
                if ((int)this._num_articulo == (int)value)
                    return;
                this.SendPropertyChanging();
                this._num_articulo = value;
                this.SendPropertyChanged(nameof(num_articulo));
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

        [Column(DbType = "SmallInt NOT NULL", Storage = "_no_captura")]
        public short no_captura
        {
            get => this._no_captura;
            set
            {
                if ((int)this._no_captura == (int)value)
                    return;
                this.SendPropertyChanging();
                this._no_captura = value;
                this.SendPropertyChanged(nameof(no_captura));
            }
        }

        [Column(DbType = "Decimal(19,3) NOT NULL", Storage = "_no_entrega")]
        public Decimal no_entrega
        {
            get => this._no_entrega;
            set
            {
                if (!(this._no_entrega != value))
                    return;
                this.SendPropertyChanging();
                this._no_entrega = value;
                this.SendPropertyChanged(nameof(no_entrega));
            }
        }

        [Association(IsForeignKey = true, Name = "articulo_compra_articulo", OtherKey = "cod_barras", Storage = "_articulo", ThisKey = "cod_barras")]
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
                    entity.compra_articulo.Remove(this);
                }
                this._articulo.Entity = value;
                if (value != null)
                {
                    value.compra_articulo.Add(this);
                    this._cod_barras = value.cod_barras;
                }
                else
                    this._cod_barras = (string)null;
                this.SendPropertyChanged(nameof(articulo));
            }
        }

        [Association(IsForeignKey = true, Name = "compra_compra_articulo", OtherKey = "id_compra", Storage = "_compra", ThisKey = "id_compra")]
        public compra compra
        {
            get => this._compra.Entity;
            set
            {
                compra entity = this._compra.Entity;
                if (entity == value && this._compra.HasLoadedOrAssignedValue)
                    return;
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._compra.Entity = (compra)null;
                    entity.compra_articulo.Remove(this);
                }
                this._compra.Entity = value;
                if (value != null)
                {
                    value.compra_articulo.Add(this);
                    this._id_compra = value.id_compra;
                }
                else
                    this._id_compra = new Guid();
                this.SendPropertyChanged(nameof(compra));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, compra_articulo.emptyChangingEventArgs);
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