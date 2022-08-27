using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Table(Name = "dbo.usuario_permiso")]
    public class usuario_permiso : INotifyPropertyChanging, INotifyPropertyChanged
    {

        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private string _user_name;
        private string _id_permiso;
        private Decimal? _valor_num;
        private DateTime _fecha_registro;
        private EntityRef<usuario> _usuario;

        #endregion

        #region Metodos de Acción
        public usuario_permiso() => this._usuario = new EntityRef<usuario>();

        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", IsPrimaryKey = true, Storage = "_user_name")]
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

        [Column(CanBeNull = false, DbType = "VarChar(15) NOT NULL", IsPrimaryKey = true, Storage = "_id_permiso")]
        public string id_permiso
        {
            get => this._id_permiso;
            set
            {
                if (!(this._id_permiso != value))
                    return;
                this.SendPropertyChanging();
                this._id_permiso = value;
                this.SendPropertyChanged(nameof(id_permiso));
            }
        }

        [Column(DbType = "Decimal(18,3)", Storage = "_valor_num")]
        public Decimal? valor_num
        {
            get => this._valor_num;
            set
            {
                Decimal? valorNum = this._valor_num;
                Decimal? nullable = value;
                if ((valorNum.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : (valorNum.HasValue != nullable.HasValue ? 1 : 0)) == 0)
                    return;
                this.SendPropertyChanging();
                this._valor_num = value;
                this.SendPropertyChanged(nameof(valor_num));
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

        [Association(IsForeignKey = true, Name = "usuario_usuario_permiso", OtherKey = "user_name", Storage = "_usuario", ThisKey = "user_name")]
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
                    entity.usuario_permiso.Remove(this);
                }
                this._usuario.Entity = value;
                if (value != null)
                {
                    value.usuario_permiso.Add(this);
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
            this.PropertyChanging((object)this, usuario_permiso.emptyChangingEventArgs);
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