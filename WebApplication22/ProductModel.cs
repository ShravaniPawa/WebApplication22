using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication22
{
    public partial class ProductModel : DbContext
    {
        public ProductModel()
            : base("name=ProductEntities")
        {
        }

       public virtual DbSet<tblProduct1> tblProduct1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
