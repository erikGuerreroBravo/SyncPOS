using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
namespace SyncPOS
{
    [Table(Name = "dbo.ctrl_errores")]
    public class ctrl_errores : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_error;
        private DateTime _fecha_log;
        private string _descripcion;
        #endregion

        #region Metodos de Accion

        [Column(DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, Storage = "_id_error")]
        public Guid id_error
        {
            get => this._id_error;
            set
            {
                if (!(this._id_error != value))
                    return;
                this.SendPropertyChanging();
                this._id_error = value;
                this.SendPropertyChanged(nameof(id_error));
            }
        }

        [Column(DbType = "DateTime NOT NULL", Storage = "_fecha_log")]
        public DateTime fecha_log
        {
            get => this._fecha_log;
            set
            {
                if (!(this._fecha_log != value))
                    return;
                this.SendPropertyChanging();
                this._fecha_log = value;
                this.SendPropertyChanged(nameof(fecha_log));
            }
        }

        [Column(CanBeNull = false, DbType = "NText NOT NULL", Storage = "_descripcion", UpdateCheck = UpdateCheck.Never)]
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

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, ctrl_errores.emptyChangingEventArgs);
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