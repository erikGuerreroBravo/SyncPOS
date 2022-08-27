using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.inventario_fisico")]
    public class inventario_fisico : INotifyPropertyChanging, INotifyPropertyChanged
    {

        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_inventario_fisico;
        private Guid _id_proveedor;
        private string _user_name;
        private DateTime _fecha_ini;
        private DateTime? _fecha_fin;
        private DateTime _fecha_registro;
        private EntitySet<SyncPOS.inventario_captura> _inventario_captura;
        private EntityRef<proveedor> _proveedor;
        private EntityRef<usuario> _usuario;
        #endregion

        #region Constructor
        public inventario_fisico()
        {
            this._inventario_captura = new EntitySet<SyncPOS.inventario_captura>(new Action<SyncPOS.inventario_captura>(this.attach_inventario_captura), new Action<SyncPOS.inventario_captura>(this.detach_inventario_captura));
            this._proveedor = new EntityRef<proveedor>();
            this._usuario = new EntityRef<usuario>();
        }
        #endregion

        #region Metodos de Acción
        [Column(DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, Storage = "_id_inventario_fisico")]
        public Guid id_inventario_fisico
        {
            get => this._id_inventario_fisico;
            set
            {
                if (!(this._id_inventario_fisico != value))
                    return;
                this.SendPropertyChanging();
                this._id_inventario_fisico = value;
                this.SendPropertyChanged(nameof(id_inventario_fisico));
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

        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", Storage = "_user_name")]
        public string user_name
        {
            get => this._user_name;
            set
            {
                if (!(this._user_name != value))
                    return;
                if (this._usuario.HasLoadedOrAssignedValue)
                    throw new ForeignKeyReferenceAlreadyHasValueException();
                this.SendPropertyChanging();
                this._user_name = value;
                this.SendPropertyChanged(nameof(user_name));
            }
        }

        [Column(DbType = "DateTime NOT NULL", Storage = "_fecha_ini")]
        public DateTime fecha_ini
        {
            get => this._fecha_ini;
            set
            {
                if (!(this._fecha_ini != value))
                    return;
                this.SendPropertyChanging();
                this._fecha_ini = value;
                this.SendPropertyChanged(nameof(fecha_ini));
            }
        }

        [Column(DbType = "DateTime", Storage = "_fecha_fin")]
        public DateTime? fecha_fin
        {
            get => this._fecha_fin;
            set
            {
                DateTime? fechaFin = this._fecha_fin;
                DateTime? nullable = value;
                if ((fechaFin.HasValue != nullable.HasValue ? 1 : (!fechaFin.HasValue ? 0 : (fechaFin.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : 0))) == 0)
                    return;
                this.SendPropertyChanging();
                this._fecha_fin = value;
                this.SendPropertyChanged(nameof(fecha_fin));
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

        [Association(Name = "inventario_fisico_inventario_captura", OtherKey = "id_inventario_fisico", Storage = "_inventario_captura", ThisKey = "id_inventario_fisico")]
        public EntitySet<SyncPOS.inventario_captura> inventario_captura
        {
            get => this._inventario_captura;
            set => this._inventario_captura.Assign((IEnumerable<SyncPOS.inventario_captura>)value);
        }

        [Association(IsForeignKey = true, Name = "proveedor_inventario_fisico", OtherKey = "id_proveedor", Storage = "_proveedor", ThisKey = "id_proveedor")]
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
                    entity.inventario_fisico.Remove(this);
                }
                this._proveedor.Entity = value;
                if (value != null)
                {
                    value.inventario_fisico.Add(this);
                    this._id_proveedor = value.id_proveedor;
                }
                else
                    this._id_proveedor = new Guid();
                this.SendPropertyChanged(nameof(proveedor));
            }
        }

        [Association(IsForeignKey = true, Name = "usuario_inventario_fisico", OtherKey = "user_name", Storage = "_usuario", ThisKey = "user_name")]
        public usuario usuario
        {
            get => this._usuario.Entity;
            set
            {
                usuario entity = this._usuario.Entity;
                if (entity == value && this._usuario.HasLoadedOrAssignedValue)
                    return;
                this.SendPropertyChanging();
                if (entity != null)
                {
                    this._usuario.Entity = (usuario)null;
                    entity.inventario_fisico.Remove(this);
                }
                this._usuario.Entity = value;
                if (value != null)
                {
                    value.inventario_fisico.Add(this);
                    this._user_name = value.user_name;
                }
                else
                    this._user_name = (string)null;
                this.SendPropertyChanged(nameof(usuario));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, inventario_fisico.emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_inventario_captura(SyncPOS.inventario_captura entity)
        {
            this.SendPropertyChanging();
            entity.inventario_fisico = this;
        }

        private void detach_inventario_captura(SyncPOS.inventario_captura entity)
        {
            this.SendPropertyChanging();
            entity.inventario_fisico = (inventario_fisico)null;
        }
        #endregion
    }
}