using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.proveedor")]
    public class proveedor : INotifyPropertyChanging, INotifyPropertyChanged
    {
       
        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_proveedor;
        private string _rfc;
        private string _razon_social;
        private string _nombre_contacto;
        private string _tel_principal;
        private string _tel_movil;
        private string _e_mail;
        private string _estatus;
        private DateTime _fecha_registro;
        private EntitySet<SyncPOS.articulo> _articulo;
        private EntitySet<SyncPOS.compra> _compra;
        private EntitySet<SyncPOS.inventario_fisico> _inventario_fisico;
        private EntitySet<SyncPOS.orden> _orden;
        #endregion

        #region Constructor
        public proveedor()
        {
            this._articulo = new EntitySet<SyncPOS.articulo>(new Action<SyncPOS.articulo>(this.attach_articulo), new Action<SyncPOS.articulo>(this.detach_articulo));
            this._compra = new EntitySet<SyncPOS.compra>(new Action<SyncPOS.compra>(this.attach_compra), new Action<SyncPOS.compra>(this.detach_compra));
            this._inventario_fisico = new EntitySet<SyncPOS.inventario_fisico>(new Action<SyncPOS.inventario_fisico>(this.attach_inventario_fisico), new Action<SyncPOS.inventario_fisico>(this.detach_inventario_fisico));
            this._orden = new EntitySet<SyncPOS.orden>(new Action<SyncPOS.orden>(this.attach_orden), new Action<SyncPOS.orden>(this.detach_orden));
        }

        #endregion

        #region Metodos

        [Column(DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, Storage = "_id_proveedor")]
        public Guid id_proveedor
        {
            get => this._id_proveedor;
            set
            {
                if (!(this._id_proveedor != value))
                    return;
                this.SendPropertyChanging();
                this._id_proveedor = value;
                this.SendPropertyChanged(nameof(id_proveedor));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(18) NOT NULL", Storage = "_rfc")]
        public string rfc
        {
            get => this._rfc;
            set
            {
                if (!(this._rfc != value))
                    return;
                this.SendPropertyChanging();
                this._rfc = value;
                this.SendPropertyChanged(nameof(rfc));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(80) NOT NULL", Storage = "_razon_social")]
        public string razon_social
        {
            get => this._razon_social;
            set
            {
                if (!(this._razon_social != value))
                    return;
                this.SendPropertyChanging();
                this._razon_social = value;
                this.SendPropertyChanged(nameof(razon_social));
            }
        }

        [Column(DbType = "VarChar(100)", Storage = "_nombre_contacto")]
        public string nombre_contacto
        {
            get => this._nombre_contacto;
            set
            {
                if (!(this._nombre_contacto != value))
                    return;
                this.SendPropertyChanging();
                this._nombre_contacto = value;
                this.SendPropertyChanged(nameof(nombre_contacto));
            }
        }

        [Column(DbType = "VarChar(20)", Storage = "_tel_principal")]
        public string tel_principal
        {
            get => this._tel_principal;
            set
            {
                if (!(this._tel_principal != value))
                    return;
                this.SendPropertyChanging();
                this._tel_principal = value;
                this.SendPropertyChanged(nameof(tel_principal));
            }
        }

        [Column(DbType = "VarChar(30)", Storage = "_tel_movil")]
        public string tel_movil
        {
            get => this._tel_movil;
            set
            {
                if (!(this._tel_movil != value))
                    return;
                this.SendPropertyChanging();
                this._tel_movil = value;
                this.SendPropertyChanged(nameof(tel_movil));
            }
        }

        [Column(DbType = "VarChar(80)", Storage = "_e_mail")]
        public string e_mail
        {
            get => this._e_mail;
            set
            {
                if (!(this._e_mail != value))
                    return;
                this.SendPropertyChanging();
                this._e_mail = value;
                this.SendPropertyChanged(nameof(e_mail));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", Storage = "_estatus")]
        public string estatus
        {
            get => this._estatus;
            set
            {
                if (!(this._estatus != value))
                    return;
                this.SendPropertyChanging();
                this._estatus = value;
                this.SendPropertyChanged(nameof(estatus));
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

        [Association(Name = "proveedor_articulo", OtherKey = "id_proveedor", Storage = "_articulo", ThisKey = "id_proveedor")]
        public EntitySet<SyncPOS.articulo> articulo
        {
            get => this._articulo;
            set => this._articulo.Assign((IEnumerable<SyncPOS.articulo>)value);
        }

        [Association(Name = "proveedor_compra", OtherKey = "id_proveedor", Storage = "_compra", ThisKey = "id_proveedor")]
        public EntitySet<SyncPOS.compra> compra
        {
            get => this._compra;
            set => this._compra.Assign((IEnumerable<SyncPOS.compra>)value);
        }

        [Association(Name = "proveedor_inventario_fisico", OtherKey = "id_proveedor", Storage = "_inventario_fisico", ThisKey = "id_proveedor")]
        public EntitySet<SyncPOS.inventario_fisico> inventario_fisico
        {
            get => this._inventario_fisico;
            set => this._inventario_fisico.Assign((IEnumerable<SyncPOS.inventario_fisico>)value);
        }

        [Association(Name = "proveedor_orden", OtherKey = "id_proveedor", Storage = "_orden", ThisKey = "id_proveedor")]
        public EntitySet<SyncPOS.orden> orden
        {
            get => this._orden;
            set => this._orden.Assign((IEnumerable<SyncPOS.orden>)value);
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, proveedor.emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_articulo(SyncPOS.articulo entity)
        {
            this.SendPropertyChanging();
            entity.proveedor = this;
        }

        private void detach_articulo(SyncPOS.articulo entity)
        {
            this.SendPropertyChanging();
            entity.proveedor = (proveedor)null;
        }

        private void attach_compra(SyncPOS.compra entity)
        {
            this.SendPropertyChanging();
            entity.proveedor = this;
        }

        private void detach_compra(SyncPOS.compra entity)
        {
            this.SendPropertyChanging();
            entity.proveedor = (proveedor)null;
        }

        private void attach_inventario_fisico(SyncPOS.inventario_fisico entity)
        {
            this.SendPropertyChanging();
            entity.proveedor = this;
        }

        private void detach_inventario_fisico(SyncPOS.inventario_fisico entity)
        {
            this.SendPropertyChanging();
            entity.proveedor = (proveedor)null;
        }

        private void attach_orden(SyncPOS.orden entity)
        {
            this.SendPropertyChanging();
            entity.proveedor = this;
        }

        private void detach_orden(SyncPOS.orden entity)
        {
            this.SendPropertyChanging();
            entity.proveedor = (proveedor)null;
        }
        #endregion

    }
}