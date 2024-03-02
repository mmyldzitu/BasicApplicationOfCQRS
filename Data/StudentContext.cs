using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {
    }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student(){Name="Muhammed",Age=28, Surname="Yıldız", Id=1},
                new Student(){Name="Kadircan", Surname="Civelek", Age=32, Id=2}


            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
