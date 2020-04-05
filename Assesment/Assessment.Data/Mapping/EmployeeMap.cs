using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Data.Mapping
{
    public class EmployeeMap:IEntityMap
    {
        public EmployeeMap(ModelBuilder builder)
        {
            builder.Entity<Models.Employee>()
                .Property(a => a.Id)
                .HasColumnName("Id");
        }
    }
}
