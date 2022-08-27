using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace SyncPOS
{
    [Table(Name = "dbo.unidad_medida")]
    public class unidad_medida : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Atributos
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(string.Empty);
        private Guid _id_unidad;
        private string _descripcion;
        private DateTime _fecha_registro;
        private EntitySet<SyncPOS.articulo> _articulo;
        #endregion

        #region Metodos de Acción
        public unidad_medida() => this._articulo = new EntitySet<SyncPOS.articulo>(new Action<SyncPOS.articulo>(this.attach_articulo), new Action<SyncPOS.articulo>(this.detach_articulo));

        [Column(DbType = "UniqueIdentifier NOT NULL", IsPrimaryKey = true, Storage = "_id_unidad")]
        public Guid id_unidad
        {
            get => this._id_unidad;
            set
            {
                if (!(this._id_unidad != value))
                    return;
                this.SendPropertyChanging();
                this._id_unidad = value;
                this.SendPropertyChanged(nameof(id_unidad));
            }
        }

        [Column(CanBeNull = false, DbType = "VarChar(10) NOT NULL", Storage = "_descripcion")]
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

        [Association(Name = "unidad_medida_articulo", OtherKey = "id_unidad", Storage = "_articulo", ThisKey = "id_unidad")]
        public EntitySet<SyncPOS.articulo> articulo
        {
            get => this._articulo;
            set => this._articulo.Assign((IEnumerable<SyncPOS.articulo>)value);
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if (this.PropertyChanging == null)
                return;
            this.PropertyChanging((object)this, unidad_medida.emptyChangingEventArgs);
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
            entity.unidad_medida = this;
        }

        private void detach_articulo(SyncPOS.articulo entity)
        {
            this.SendPropertyChanging();
            entity.unidad_medida = (unidad_medida)null;
        }
        #endregion

    }
}