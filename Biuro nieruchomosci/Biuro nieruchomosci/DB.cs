namespace Biuro_nieruchomosci
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<FlatForClient> FlatForClient { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Parking> Parking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>()
                .Property(e => e.Cost_sm)
                .HasPrecision(18, 4);
        }
    }
}
