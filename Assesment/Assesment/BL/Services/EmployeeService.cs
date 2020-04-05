using Assesment.API.BL.Interfaces;
using Assessment.Data.Interfaces;
using Assessment.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment.API.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _repository.GetAsync(id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.GetAllAsync();
            return employees;
        }

        public async Task<Employee> InserEmployee(Employee employee)
        {
            await _repository.AddAsync(employee);
            return employee;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var targetEmployee = await _repository.GetAsync(id);
            if(targetEmployee!= null)
            {
                targetEmployee.FullName = employee.FullName;
                targetEmployee.Email = employee.Email;
                targetEmployee.Mobile = employee.Mobile;
                targetEmployee.City = employee.City;
                targetEmployee.Gender = employee.Gender;
                targetEmployee.Department = employee.Department;
                targetEmployee.IsPermanent = employee.IsPermanent;
                targetEmployee.HireDate = employee.HireDate;
                await _repository.UpdateAsync(targetEmployee);
                return targetEmployee;
            }
            return null;
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            var targetDelete = await _repository.GetAsync(id);
            if(targetDelete != null)
            {
                await _repository.DeleteAsync(targetDelete.Id);
                return true;
            }
            return false;
        }
    }
}
