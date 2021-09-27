using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.BL
{
    public class Contexto: DbContext
    {
        public Contexto():base("ClothingStoreDB")
        {

        }
        public DbSet<Producto> Productos { get; set; }
    }
}
