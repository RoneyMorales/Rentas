using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BL.Rentas
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Server=DESKTOP-3NEEON0;Database=VideoJuegos2;Trusted_Connection=True; ")
            //DESKTOP-3NEEON0
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
            //Agrega Datos de Inicio despues de ELIMINARLA
        }

        public DbSet<Producto> Productos{ get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Factura> Facturas { get; set; }

    }
}
