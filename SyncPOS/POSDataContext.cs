using SyncPOS.Properties;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SyncPOS
{
    [Database(Name = "pos_admin")]
    public class POSDataContext : DataContext
    {
        private static MappingSource mappingSource = (MappingSource)new AttributeMappingSource();

        public POSDataContext()
          : base(Settings.Default.pos_adminConnectionString, POSDataContext.mappingSource)
        {
        }

        public POSDataContext(string connection)
          : base(connection, POSDataContext.mappingSource)
        {
        }

        public POSDataContext(IDbConnection connection)
          : base(connection, POSDataContext.mappingSource)
        {
        }

        public POSDataContext(string connection, MappingSource mappingSource)
          : base(connection, mappingSource)
        {
        }

        public POSDataContext(IDbConnection connection, MappingSource mappingSource)
          : base(connection, mappingSource)
        {
        }

        public Table<SyncPOS.articulo> articulo => this.GetTable<SyncPOS.articulo>();

        public Table<SyncPOS.compra> compra => this.GetTable<SyncPOS.compra>();

        public Table<SyncPOS.compra_articulo> compra_articulo => this.GetTable<SyncPOS.compra_articulo>();

        public Table<SyncPOS.ctrl_errores> ctrl_errores => this.GetTable<SyncPOS.ctrl_errores>();

        public Table<SyncPOS.inventario_captura> inventario_captura => this.GetTable<SyncPOS.inventario_captura>();

        public Table<SyncPOS.inventario_fisico> inventario_fisico => this.GetTable<SyncPOS.inventario_fisico>();

        public Table<SyncPOS.orden> orden => this.GetTable<SyncPOS.orden>();

        public Table<SyncPOS.orden_articulo> orden_articulo => this.GetTable<SyncPOS.orden_articulo>();

        public Table<SyncPOS.proveedor> proveedor => this.GetTable<SyncPOS.proveedor>();

        public Table<SyncPOS.usuario_permiso> usuario_permiso => this.GetTable<SyncPOS.usuario_permiso>();

        public Table<SyncPOS.usuario> usuario => this.GetTable<SyncPOS.usuario>();

        public Table<SyncPOS.unidad_medida> unidad_medida => this.GetTable<SyncPOS.unidad_medida>();
    }
}