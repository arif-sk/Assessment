using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assessment.Data.Context
{
    public class AssessmentContext : DbContext
    {
        public AssessmentContext(DbContextOptions<AssessmentContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var maps = GetMappingClasses();
            foreach (var item in maps)
                Activator.CreateInstance(item, BindingFlags.Public | BindingFlags.Instance, null, new object[] { modelBuilder }, null);
        }
        private List<Type> GetMappingClasses()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => typeof(IEntityMap).IsAssignableFrom(type) && type.IsClass)
               .ToList();
        }
    }
}
