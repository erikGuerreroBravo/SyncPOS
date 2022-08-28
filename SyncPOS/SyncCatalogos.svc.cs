using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SyncPOS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SyncCatalogos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SyncCatalogos.svc o SyncCatalogos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SyncCatalogos : ISyncCatalogos
    {
        public void DoWork()
        {
        }
    }
}
