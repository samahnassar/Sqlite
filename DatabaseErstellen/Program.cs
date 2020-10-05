using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Transactions;

namespace DatabaseErstellen
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolContext())
            {
                // Create
                Console.WriteLine("Inserting a new Course");
                
                db.Add(new Kurs {KuId = 1 });
                db.SaveChanges();
                db.Add(new Kurs { KuId = 2 });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a Course");
                var kurs = db.Kurse
                    .OrderBy(b => b.KuId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a Student");
                kurs.Datum = DateTime.Now;
                for (int i = 1; i < 100; i++)
                {
                    Console.WriteLine("Geben Sie ein Student ein:");
                    kurs.Studenten.Add(
                      new Student
                      {   StuId = i,
                          Name = Console.ReadLine(),
                          Vorname = Console.ReadLine(),
                      });
                    db.SaveChanges();
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        break;
                    db.SaveChanges();
                }
                // Delete
                //Console.WriteLine("Delete the Course");
                //db.Remove(kurs);
                db.SaveChanges();
            }
        }

        private static IOrderedQueryable<Student> create(SchoolContext db)
        {
            return db.Studenten
                          .OrderBy(b => b.StuId);
            
        }
    }
}
