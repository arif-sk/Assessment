using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment.API.BL.Interfaces;
using Assessment.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var employee = await _service.GetEmployee(id);
            if (employee == null)
                return NotFound();
            return employee;

        }
        public Task<IEnumerable<Employee>> Get()
        {
            var employees = _service.GetEmployees();
            return employees;
        }

        [HttpPost("Create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Employee>> Create([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var addedEmployee = await _service.InserEmployee(employee);
            return CreatedAtRoute("GetEmployee", new { id = addedEmployee.Id }, addedEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, [FromBody] Employee employee)
        {
            if (id < 1)
                return BadRequest();
            var updatedEmployee = await _service.UpdateEmployee(id,employee);
            if (updatedEmployee == null)
                return NotFound();
            return updatedEmployee;
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var resDelete = await _service.DeleteEmployee(id);
            if (!resDelete)
                return NotFound();
            return true;
        }
    }
}