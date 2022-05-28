using Garage.DAO.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Garage.DAO.Context
{
    public partial class GarageContext : DbContext
    {
        public GarageContext()
            : base("name=GarageContext")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Model.Garage> Garages { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
