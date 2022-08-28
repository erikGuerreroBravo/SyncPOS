using SyncPOS.domain;
using SyncPOS.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SyncPOS
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SyncCatalogos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SyncCatalogos.svc o SyncCatalogos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SyncCatalogos : ISyncCatalogos
    {
        public List<SyncPOS.domain.unidad_medida> getUnidades(string lastChangeDateTime)
        {
            using (POSDataContext posDataContext = new POSDataContext())
            {
                if (lastChangeDateTime.Equals((object)DateTime.Parse("01/01/2017 07:00:00")))
                    return posDataContext.unidad_medida.Select<unidad_medida, SyncPOS.domain.unidad_medida>((Expression<Func<unidad_medida, SyncPOS.domain.unidad_medida>>)(e => new SyncPOS.domain.unidad_medida()
                    {
                        id_unidad = e.id_unidad,
                        descripcion = e.descripcion,
                        fecha_registro = DateTime.Now
                    })).ToList<SyncPOS.domain.unidad_medida>();
                return posDataContext.unidad_medida.Where<unidad_medida>((Expression<Func<unidad_medida, bool>>)(e => e.fecha_registro > DateTime.Parse(lastChangeDateTime))).Select<unidad_medida, SyncPOS.domain.unidad_medida>((Expression<Func<unidad_medida, SyncPOS.domain.unidad_medida>>)(e => new SyncPOS.domain.unidad_medida()
                {
                    id_unidad = e.id_unidad,
                    descripcion = e.descripcion,
                    fecha_registro = e.fecha_registro
                })).ToList<SyncPOS.domain.unidad_medida>();
            }
        }

        public List<SyncPOS.domain.proveedor> getProveedores(string lastChangeDateTime)
        {
            using (POSDataContext posDataContext = new POSDataContext())
                return posDataContext.proveedor.Where<proveedor>((Expression<Func<proveedor, bool>>)(a => a.fecha_registro > DateTime.Parse(lastChangeDateTime))).Select<proveedor, SyncPOS.domain.proveedor>((Expression<Func<proveedor, SyncPOS.domain.proveedor>>)(e => new SyncPOS.domain.proveedor()
                {
                    id_proveedor = e.id_proveedor,
                    rfc = e.rfc,
                    razon_social = e.razon_social,
                    estatus = e.estatus,
                    last_change_datetime = e.fecha_registro
                })).ToList<SyncPOS.domain.proveedor>();
        }


        public List<SyncPOS.domain.articulo> getArticulos(string lastChangeDateTime)
        {
            using (POSDataContext posDataContext = new POSDataContext())
                return posDataContext.articulo.Where<articulo>((Expression<Func<articulo, bool>>)(a => a.fecha_registro > DateTime.Parse(lastChangeDateTime) && a.kit.Equals(false))).OrderBy<articulo, DateTime>((Expression<Func<articulo, DateTime>>)(a => a.fecha_registro)).Select<articulo, SyncPOS.domain.articulo>((Expression<Func<articulo, SyncPOS.domain.articulo>>)(a => new SyncPOS.domain.articulo()
                {
                    cod_barras = a.cod_barras,
                    cod_asociado = a.cod_asociado,
                    id_clasificacion = a.id_clasificacion,
                    cod_interno = a.cod_interno,
                    descripcion = a.descripcion,
                    descripcion_corta = a.descripcion_corta,
                    cantidad_um = a.cantidad_um,
                    id_unidad = a.id_unidad,
                    id_proveedor = a.id_proveedor,
                    precio_compra = a.precio_compra,
                    utilidad = a.utilidad,
                    precio_venta = a.precio_venta,
                    tipo_articulo = a.tipo_articulo,
                    stock = a.stock,
                    stock_min = a.stock_min,
                    stock_max = a.stock_max,
                    iva = a.iva,
                    articulo_disponible = a.articulo_disponible,
                    kit = a.kit,
                    fecha_registro = a.fecha_registro,
                    visible = a.visible,
                    puntos = a.puntos,
                    last_update_inventory = a.last_update_inventory
                })).ToList<SyncPOS.domain.articulo>();
        }

        public List<SyncPOS.domain.usuario> getUsuarios(string lastChangeDateTime)
        {
            using (POSDataContext posDataContext = new POSDataContext())
            {
                if (lastChangeDateTime.Equals((object)DateTime.Parse("01/01/2017 07:00:00")))
                    return posDataContext.usuario.Select<usuario, SyncPOS.domain.usuario>((Expression<Func<usuario, SyncPOS.domain.usuario>>)(e => new SyncPOS.domain.usuario()
                    {
                        user_name = e.user_name,
                        password = e.password,
                        tipo_usuario = e.tipo_usuario,
                        enable = e.enable,
                        fecha_registro = DateTime.Now
                    })).ToList<SyncPOS.domain.usuario>();
                return posDataContext.usuario.Where<usuario>((Expression<Func<usuario, bool>>)(u => u.fecha_registro > DateTime.Parse(lastChangeDateTime))).Select<usuario, SyncPOS.domain.usuario>((Expression<Func<usuario, SyncPOS.domain.usuario>>)(u => new SyncPOS.domain.usuario()
                {
                    user_name = u.user_name,
                    password = u.password,
                    tipo_usuario = u.tipo_usuario,
                    enable = u.enable,
                    fecha_registro = u.fecha_registro
                })).ToList<SyncPOS.domain.usuario>();
            }
        }

        public List<SyncPOS.domain.usuario_permiso> getPermisosUsuarios(string lastChangeDateTime)
        {
            using (POSDataContext posDataContext = new POSDataContext())
            {
                if (lastChangeDateTime.Equals((object)DateTime.Parse("01/01/2017 07:00:00")))
                    return posDataContext.usuario_permiso.Select<usuario_permiso, SyncPOS.domain.usuario_permiso>((Expression<Func<usuario_permiso, SyncPOS.domain.usuario_permiso>>)(u => new SyncPOS.domain.usuario_permiso()
                    {
                        user_name = u.user_name,
                        id_permiso = u.id_permiso,
                        valor_num = u.valor_num ?? 0.000M,
                        fecha_registro = u.fecha_registro
                    })).ToList<SyncPOS.domain.usuario_permiso>();
                return posDataContext.usuario_permiso.Where<usuario_permiso>((Expression<Func<usuario_permiso, bool>>)(up => up.fecha_registro > DateTime.Parse(lastChangeDateTime))).Select<usuario_permiso, SyncPOS.domain.usuario_permiso>((Expression<Func<usuario_permiso, SyncPOS.domain.usuario_permiso>>)(up => new SyncPOS.domain.usuario_permiso()
                {
                    user_name = up.user_name,
                    id_permiso = up.id_permiso,
                    valor_num = up.valor_num ?? 0.000M,
                    fecha_registro = up.fecha_registro
                })).ToList<SyncPOS.domain.usuario_permiso>();
            }
        }

        public List<pedido> GetOrders(string lastChangeDateTime)
        {
            using (POSDataContext posDataContext = new POSDataContext())
                return posDataContext.orden.Where<orden>((Expression<Func<orden, bool>>)(a => a.fecha_registro > DateTime.Parse(lastChangeDateTime))).Select<orden, pedido>((Expression<Func<orden, pedido>>)(a => new pedido()
                {
                    id_pedido = a.id_pedido,
                    num_pedido = a.num_pedido,
                    fecha_pedido = a.fecha_pedido,
                    id_proveedor = a.id_proveedor,
                    status_pedido = a.status_pedido,
                    fecha_registro = a.fecha_registro
                })).ToList<pedido>();
        }

        public List<pedido_articulo> GetOrderDetail(Guid id_pedido)
        {
            using (POSDataContext posDataContext = new POSDataContext())
                return posDataContext.orden_articulo.Where<orden_articulo>((Expression<Func<orden_articulo, bool>>)(a => a.id_pedido.Equals(id_pedido))).Select<orden_articulo, pedido_articulo>((Expression<Func<orden_articulo, pedido_articulo>>)(a => new pedido_articulo()
                {
                    id_pedido = a.id_pedido,
                    no_articulo = a.no_articulo,
                    cod_barras = a.cod_barras,
                    cod_anexo = a.cod_anexo,
                    cantidad = a.cantidad,
                    precio_articulo = a.precio_articulo,
                    por_surtir = a.por_surtir,
                    por_surtir_pzas = a.por_surtir_pzas,
                    fecha_registro = a.fecha_registro
                })).ToList<pedido_articulo>();
        }

        public List<pedido_articulo> GetOrderDetailUpdate(string lastChangeDateTime)
        {
            using (POSDataContext posDataContext = new POSDataContext())
                return posDataContext.orden_articulo.Where<orden_articulo>((Expression<Func<orden_articulo, bool>>)(a => a.fecha_registro > DateTime.Parse(lastChangeDateTime))).Select<orden_articulo, pedido_articulo>((Expression<Func<orden_articulo, pedido_articulo>>)(a => new pedido_articulo()
                {
                    id_pedido = a.id_pedido,
                    no_articulo = a.no_articulo,
                    cod_barras = a.cod_barras,
                    cod_anexo = a.cod_anexo,
                    cantidad = a.cantidad,
                    precio_articulo = a.precio_articulo,
                    por_surtir = a.por_surtir,
                    por_surtir_pzas = a.por_surtir_pzas,
                    fecha_registro = a.fecha_registro
                })).ToList<pedido_articulo>();
        }


        public List<SyncPOS.domain.inventario_fisico> GetInventarios(string lastChangeDateTime)
        {
            using (POSDataContext posDataContext = new POSDataContext())
                return posDataContext.inventario_fisico.Where<inventario_fisico>((Expression<Func<inventario_fisico, bool>>)(e => e.fecha_registro > DateTime.Parse(lastChangeDateTime))).Select<inventario_fisico, SyncPOS.domain.inventario_fisico>((Expression<Func<inventario_fisico, SyncPOS.domain.inventario_fisico>>)(e => new SyncPOS.domain.inventario_fisico()
                {
                    id_inventario_fisico = e.id_inventario_fisico,
                    id_proveedor = e.id_proveedor,
                    user_name = e.user_name,
                    fecha_ini = e.fecha_ini,
                    fecha_fin = e.fecha_fin == new DateTime?() ? e.fecha_fin.ToString() : default(string),
                    fecha_registro = e.fecha_registro
                })).ToList<SyncPOS.domain.inventario_fisico>();
        }

        public bool SetInventarios(SyncPOS.domain.inventario_captura p)
        {
            try
            {
                using (POSDataContext posDataContext = new POSDataContext())
                {
                    if (posDataContext.inventario_captura.FirstOrDefault<inventario_captura>((Expression<Func<inventario_captura, bool>>)(e => e.id_inventario_fisico.Equals(new Guid(p.id_inventario_fisico)) && e.num_captura.Equals(long.Parse(p.num_captura)) && e.cod_barras.Equals(p.cod_barras))) == null)
                    {
                        inventario_captura entity = new inventario_captura()
                        {
                            id_captura = new Guid(p.id_captura),
                            id_inventario_fisico = new Guid(p.id_inventario_fisico),
                            num_captura = long.Parse(p.num_captura),
                            cod_barras = p.cod_barras,
                            fecha_captura = DateTime.Parse(p.fecha_captura),
                            cant_cja = Decimal.Parse(p.cant_cja),
                            cant_pza = Decimal.Parse(p.cant_pza)
                        };
                        posDataContext.inventario_captura.InsertOnSubmit(entity);
                        posDataContext.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                CtrlException.SetErrorDB(ex.Message);
                return false;
            }
        }

        public bool CreatePurchase(SyncPOS.domain.compra p)
        {
            try
            {
                using (POSDataContext posDataContext = new POSDataContext())
                {
                    if (posDataContext.compra.FirstOrDefault<compra>((Expression<Func<compra, bool>>)(c => c.id_compra.Equals(p.id_compra))) == null)
                    {
                        posDataContext.compra.InsertOnSubmit(new compra()
                        {
                            id_compra = Guid.Parse(p.id_compra),
                            id_proveedor = p.id_proveedor != null ? new Guid?(Guid.Parse(p.id_proveedor)) : new Guid?(),
                            no_factura = (string)null,
                            fecha_compra = DateTime.Parse(p.fecha_compra),
                            id_pedido = p.id_pedido != null ? new Guid?(Guid.Parse(p.id_pedido)) : new Guid?(),
                            cancelada = false,
                            fecha_cancelacion = new DateTime?(),
                            no_entrada = (short)0,
                            observaciones = (string)null
                        });
                        posDataContext.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                CtrlException.SetErrorDB("Compras: " + ex.Message);
                return false;
            }
        }


        public bool CreatePurchaseDetail(SyncPOS.domain.compra_articulo p)
        {
            try
            {
                using (POSDataContext posDataContext = new POSDataContext())
                {
                    if (posDataContext.compra_articulo.FirstOrDefault<compra_articulo>((Expression<Func<compra_articulo, bool>>)(c => c.id_compra.Equals(p.id_compra) && c.cod_barras.Equals(p.cod_barras) && c.num_articulo.Equals(p.num_articulo))) == null)
                    {
                        posDataContext.compra_articulo.InsertOnSubmit(new compra_articulo()
                        {
                            id_compra = Guid.Parse(p.id_compra),
                            cod_barras = p.cod_barras,
                            num_articulo = short.Parse(p.num_articulo),
                            cant_cja = Decimal.Parse(p.cant_cja),
                            cant_pza = Decimal.Parse(p.cant_pza),
                            precio_compra = Decimal.Parse(p.precio_compra),
                            no_captura = short.Parse(p.no_captura),
                            no_entrega = Decimal.Parse(p.no_entrega)
                        });
                        posDataContext.SubmitChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                CtrlException.SetErrorDB("Detalle Compras: " + ex.Message);
                return false;
            }
        }

        public void DoWork()
        {
        }
    }
}
