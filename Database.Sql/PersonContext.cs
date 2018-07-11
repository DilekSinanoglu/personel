using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PersonLibrary;
using System.ComponentModel.DataAnnotations.Schema;

namespace personelKayit_dosyaOkuma_
{
    class PersonContext:DbContext
    {
        public PersonContext() : base("PersonDbEntities1")
        {
            System.Data.Entity.Database.SetInitializer<PersonContext>(null); 
        }

        #region DbSets (Tablolar)
        public DbSet<Person> Persons { get; set; }    
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Person>()
                .ToTable("Persons")
                .HasKey(x => x.Id)
                .Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }

    internal sealed class FepazoConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<PersonContext>
    {
        public FepazoConfiguration()
        {
            AutomaticMigrationsEnabled = true; // Veritabanını buradaki modellere göre son haline güncelleme
            AutomaticMigrationDataLossAllowed = true; // Bu güncelleme işlemi yaparken olabilecek veri kaybına izin verme (true)
        }
    }
}
