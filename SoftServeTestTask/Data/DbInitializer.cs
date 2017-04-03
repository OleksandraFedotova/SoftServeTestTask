using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftServeTestTask.Models;

namespace SoftServeTestTask.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context )
        {
            context.Database.EnsureCreated();

            if (context.Organizations.Any())
            {
                return;
            }

            var organization = new Organization {OrganizationId=1,Code = "125368", Name = "IdealSoft"};

            context.Organizations.Add(organization);

            context.SaveChanges();
        }
    }
}
