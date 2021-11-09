using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BL
{
   public class ReporteVentasporProductoBL
    {
        Contexto _Contexto;
        public List<ReporteVentasporProducto> ListadeVentasPorProducto { get; set; }

        public ReporteVentasporProductoBL()
        {
            _Contexto = new Contexto();
            ListadeVentasPorProducto = new List<ReporteVentasporProducto>();
        }
        public List<ReporteVentasporProducto> ObtenerVentasporProducto()
        {
            ListadeVentasPorProducto = _Contexto.OrdenDetalle
                .Include("Producto")
                .Where(r => r.Orden.Activo)
                .GroupBy(r => r.Producto.Descripcion)
                .Select(r => new ReporteVentasporProducto()
                {
                    Producto = r.Key,
                    Cantidad = r.Sum(s => s.Cantidad),
                    Total = r.Sum(s => s.Total)
                }).ToList();

            return ListadeVentasPorProducto;
        }
    }
}
