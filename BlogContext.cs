using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVCTraining.Models
{
    public sealed class BlogContext : DbContext
    {
        static BlogContext()
        {
            Database.SetInitializer<BlogContext>(null);
        }

        public BlogContext()
            : base("name=TABFusionRMSContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StudentModel> StudentModels { get; set; }
    }
}