using Assesment.API.BL.Interfaces;
using Assesment.API.BL.Services;
using Assessment.Data.Interfaces;
using Assessment.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment.API.ExtentionMethods
{
    public static class InjectDependency
    {
        public static void InjectRepository(this IServiceCollection service)
        {
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }

        public static void InjectService(this IServiceCollection service)
        {
            service.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
