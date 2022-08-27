using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.usuario")]
    public class usuario : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private string _user_name;
        private string _password;
        private string _tipo_usuario;
        private bool _enable;
        private short? _user_code_bascula;
        private DateTime _fecha_registro;
        private EntitySet<SyncPOS.inventario_fisico> _inventario_fisico;
        private EntitySet<SyncPOS.usuario_permiso> _usuario_permiso;
        #endregion

        #region Constructor
        public usuario()
        {
            this._inventario_fisico = new EntitySet<SyncPOS.inventario_fisico>(new Action<SyncPOS.inventario_fisico>(this.attach_inventario_fisico), new Action<SyncPOS.inventario_fisico>(this.detach_inventario_fisico));
            this._usuario_permiso = new EntitySet<SyncPOS.usuario_permiso>(new Action<SyncPOS.usuario_permiso>(this.attach_usuario_permiso), new Action<SyncPOS.usuario_permiso>(this.detach_usuario_permiso));
        }
        #endregion

        #region Metodos de Acción
        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", IsPrimaryKey = true, Storage = "_user_name")]
        public string user_name
        {
            get => this._user_name;
            set
            {
                if (!(this._user_name != value))
                    return;
                this.SendPropertyChanging();
                this._user_name = value;
                this.SendPropertyChanged(nameof(user_name));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(50) NOT NULL", Storage = "_password")]
        public string password
        {
            get => this._password;
            set
            {
                if (!(this._password != value))
                    return;
                this.SendPropertyChanging();
                this._password = value;
                this.SendPropertyChanged(nameof(password));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(30) NOT NULL", Storage = "_tipo_usuario")]
        public string tipo_usuario
        {
            get => this._tipo_usuario;
            set
            {
                if (!(this._tipo_usuario != value))
                    return;
                this.SendPropertyChanging();
                this._tipo_usuario = value;
                this.SendPropertyChanged(nameof(tipo_usuario));
            }
        }

        [Column(DbType = "Bit NOT NULL", Storage = "_enable")]
        public bool enable
        {
            get => this._enable;
            set
            {
                if (this._enable == value)
                    return;
                this.SendPropertyChanging();
                this._enable = value;
                this.SendPropertyChanged(nameof(enable));
            }
        }

        [Column(DbType = "SmallInt", Storage = "_user_code_bascula")]
        public short? user_code_bascula
        {
            get => this._user_code_bascula;
            set
            {
                short? userCodeBascula = this._user_code_bascula;
                short? nullable = value;
                if (((int)userCodeBascula.GetValueOrDefault() != (int)nullable.GetValueOrDefault() ? 1 : (userCodeBascula.HasValue != nullable.HasValue ? 1 : 0)) == 0)
                    return;
                this.SendPropertyChanging();
                this._user_code_bascula = value;
                this.SendPropertyChanged(nameof(user_code_bascula));
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

        [Association(Name = "usuario_inventario_fisico", OtherKey = "user_name", Storage = "_inventario_fisico", ThisKey = "user_name")]
        public EntitySet<SyncPOS.inventario_fisico> inventario_fisico
        {
            get => this._inventario_fisico;
            set => this._inventario_fisico.Assign((IEnumerable<SyncPOS.inventario_fisico>)value);
        }

        [Association(Name = "usuario_usuario_permiso", OtherKey = "user_name", Storage = "_usuario_permiso", ThisKey = "user_name")]
        public EntitySet<SyncPOS.usuario_permiso> usuario_permiso
        {
            get => this._usuario_permiso;
            set => this._usuario_permiso.Assign((IEnumerable<SyncPOS.usuario_permiso>)value);
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, usuario.emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_inventario_fisico(SyncPOS.inventario_fisico entity)
        {
            this.SendPropertyChanging();
            entity.usuario = this;
        }

        private void detach_inventario_fisico(SyncPOS.inventario_fisico entity)
        {
            this.SendPropertyChanging();
            entity.usuario = (usuario)null;
        }

        private void attach_usuario_permiso(SyncPOS.usuario_permiso entity)
        {
            this.SendPropertyChanging();
            entity.usuario = this;
        }

        private void detach_usuario_permiso(SyncPOS.usuario_permiso entity)
        {
            this.SendPropertyChanging();
            entity.usuario = (usuario)null;
        }
        #endregion
    }
}