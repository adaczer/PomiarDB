using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ModalTut.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ModalTut.DAL
{
    public class ModalContext : IdentityDbContext<ApplicationUser>
    {
        public ModalContext() : base("ModalConnectionString")
        {
            Database.SetInitializer<ModalContext>(new CreateDatabaseIfNotExists<ModalContext>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<ModalContext>());

            //Database.SetInitializer<ModalContext>(null);


            //Database.SetInitializer<ModalContext>(new DropCreateDatabaseIfModelChanges<ModalContext>());



        }

        public static ModalContext Create()
        {
            return new ModalContext();
        }


        public DbSet<Pomiar> Pomiars { get; set; }
        public DbSet<Items> Items { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //      .Property(a => a.StudentId)
        //      .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    base.OnModelCreating(modelBuilder);
        //}


    }
}
