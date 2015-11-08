namespace FirstIterationVMC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FirstIterationVMC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FirstIterationVMC.Models.VolunteerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FirstIterationVMC.Models.VolunteerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Volunteer.AddOrUpdate(i => i.ID,
                new Volunteer
                {
                    ID = 1,
                    FName = "Nadiia",
                    LName = "Semenchuk",
                    DOB = DateTime.Parse("01/01/1987"),
                    phone = "(904)786-6767",
                    Email = "ahig@gmail.com",
                    Address = "10789 Nice Street",
                    City = "Jacksonville",
                    State = "FL",
                    Zip = "32225",
                    Specialty = "Nurse"
                },
                new Volunteer
                {
                    ID = 2,
                    FName = "Marie",
                    LName = "Davis",
                    DOB = DateTime.Parse("04/06/1978"),
                    phone = "(904)789-5634",
                    Email = "yuioigh67@gmail.com",
                    Address = "908 Another Street",
                    City = "Jacksonville",
                    State = "FL",
                    Zip = "32225",
                    Specialty = "Pediatrics"
                },
                new Volunteer
                {
                    ID = 3,
                    FName = "Jack",
                    LName = "London",
                    DOB = DateTime.Parse("01/01/1969"),
                    phone = "(904)678-4589",
                    Email = "yuiogvhj@gmail.com",
                    Address = "Atlantic Blvd N",
                    City = "Jacksonville",
                    State = "FL",
                    Zip = "32225",
                    Specialty = "Primary Care"
                },
                new Volunteer
                {
                    ID = 4,
                    FName = "Gabriella",
                    LName = "Malada",
                    DOB = DateTime.Parse("12/07/1967"),
                    phone = "(904)789-5667",
                    Email = "yuirfbgfhk@gmail.com",
                    Address = "10789 Nice Street",
                    City = "Jacksonville",
                    State = "FL",
                    Zip = "32225",
                    Specialty = "Nurse"
                }
                );

        }
    }
}
