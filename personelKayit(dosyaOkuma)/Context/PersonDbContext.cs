using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;
namespace personelKayit_dosyaOkuma_.Context
{
    public class PersonDbContext: DbContext
    {
        public PersonDbContext():base("PersonDbContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PersonDbContext, FepazoConfiguration>("PersonDbContext"));

        }
        public virtual DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
