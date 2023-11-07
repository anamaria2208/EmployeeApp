using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Repositories.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees() {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult> GetEmplyee(int id){
            var zaposlenik = await _repository.GetById(id);
            if (zaposlenik == null) return NotFound("Employee was not found");
            return Ok(await _repository.GetById(id));
        }
        

    }
}