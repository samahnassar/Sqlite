using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Text;

namespace DatabaseErstellen
{
    public class SchoolContext : DbContext
    {

        public SchoolContext() 
        { }
        public virtual DbSet<Student> Studenten { get; set; }
        public virtual DbSet<Kurs> Kurse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=School.db");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=Person.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>(entity =>
                {
                    entity.HasKey(v => v.StuId);
                });
            modelBuilder
                 .Entity<Kurs>(entity =>
                 {
                     entity.HasKey(v => v.KuId);                     ;
                 });
        }
    }

    public class Student
    { 
        public int StuId { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }

    }

    public class Kurs
    {
        public int KuId { get; set; }
        public DateTime Datum { get; set; }
        public int StuId { get; set; }
        public List<Student> Studenten { get; } = new List<Student>();
    }
}
