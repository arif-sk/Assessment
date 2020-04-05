using Assessment.Data.Context;
using Assessment.Data.Interfaces;
using Assessment.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Data.Repositories
{
    public class EmployeeRepository: GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AssessmentContext _context;
        public EmployeeRepository(AssessmentContext context) : base(context)
        {

        }
    }
}
