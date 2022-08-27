using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SyncPOS.exceptions
{
    public class CtrlException
    {
        private static string fileName = string.Format("{0}\\error.log", (object)AppDomain.CurrentDomain.BaseDirectory);

        public static void SetError(string msg)
        {
            if (!File.Exists(CtrlException.fileName))
                File.Create(CtrlException.fileName).Dispose();
            TextWriter textWriter = (TextWriter)new StreamWriter(CtrlException.fileName, true);
            textWriter.WriteLine(string.Format("{0} - {1}", (object)DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), (object)msg));
            textWriter.Close();
        }

        public static void SetErrorDB(string Message)
        {
            using (POSDataContext posDataContext = new POSDataContext())
            {
                /*
                posDataContext.ctrl_errores.InsertOnSubmit(new ctrl_errores()
                {
                    id_error = Guid.NewGuid(),
                    fecha_log = DateTime.Now,
                    descripcion = Message
                });*/
                posDataContext.SubmitChanges();
            }
        }

    }
}