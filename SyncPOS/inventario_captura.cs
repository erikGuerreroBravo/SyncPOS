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
    }
}