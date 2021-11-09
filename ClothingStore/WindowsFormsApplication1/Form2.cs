using ClothingStore.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        ReporteVentasporProductoBL _reporteVentasPorProductoBL;
        public Form2()
        {
            InitializeComponent();
            _reporteVentasPorProductoBL = new ReporteVentasporProductoBL();
            RefrescarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            var listaVentasPorProducto = _reporteVentasPorProductoBL.ObtenerVentasporProducto();
            listadeVentasPorProductoBindingSource.DataSource = listaVentasPorProducto;

            listadeVentasPorProductoBindingSource.ResetBindings(false);
        }
    }
}
