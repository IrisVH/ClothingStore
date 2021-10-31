using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BL
{
   public class OrdenesBL
    {
        Contexto _Contexto;
        public List<Orden> ListadeOrdenes { get; set; }

        public OrdenesBL()
        {
            _Contexto = new Contexto();
            ListadeOrdenes = new List<Orden>();
        }

        public List<Orden> ObtenerOrdenes()
        {
            ListadeOrdenes = _Contexto.Ordenes
                .Include("Cliente")
                .ToList();

            return ListadeOrdenes;
                
        }
        public List<OrdenDetalle> ObtenerOrdenDetalle(int ordenId)
        {
            var listadeOrdenesDetalle = _Contexto.OrdenDetalle
                .Include("Producto")
                .Where(o => o.OrdenId == ordenId).ToList();

            return listadeOrdenesDetalle;
        }

        public OrdenDetalle ObtenerOrdenDetallePorId(int id)
        {
            var ordenDetalle = _Contexto.OrdenDetalle
                .Include("Producto").FirstOrDefault(p => p.Id == id);

            return ordenDetalle;
        }

        public Orden ObtenerOrden(int id)
        {
            var orden = _Contexto.Ordenes
                .Include("Cliente").FirstOrDefault(p => p.Id == id);

            return orden;
        }
        public void GuardarOrden(Orden orden)
        {
            if (orden.Id == 0)
            {
                _Contexto.Ordenes.Add(orden);
            }
            else
            {
                var ordenExistente = _Contexto.Ordenes.Find(orden.Id);
                ordenExistente.ClienteId = orden.ClienteId;
                ordenExistente.Activo = orden.Activo;
            }

            _Contexto.SaveChanges();
        }
        public void GuardarOrdenDetalle(OrdenDetalle ordenDetalle)
        {
            var producto = _Contexto.Productos.Find(ordenDetalle.ProductoId);
            ordenDetalle.Precio = producto.Precio;
            ordenDetalle.Total = ordenDetalle.Cantidad * ordenDetalle.Precio;

            _Contexto.OrdenDetalle.Add(ordenDetalle);

            var orden = _Contexto.Ordenes.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total + ordenDetalle.Total;
            _Contexto.SaveChanges();

        }
        public void EliminarOrdenDetalle(int id)
        {
            var ordenDetalle = _Contexto.OrdenDetalle.Find(id);
            _Contexto.OrdenDetalle.Remove(ordenDetalle);

            var orden = _Contexto.Ordenes.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total - ordenDetalle.Total;

            _Contexto.SaveChanges();

        }

    }
}
