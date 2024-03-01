using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Utitmate.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EmployeesController(IRepositoryManager repositoryManager, IMapper mapper) {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetCompanyEmployees(Guid companyId) {


            var employeesFromDb = await _repositoryManager.Employee.GetEmployees(companyId, trackChanges: false);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return Ok(employeesDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid CompanyId,Guid Id, bool trackChange)
        {
            var company = _repositoryManager.Company.GetCompanyById(CompanyId, trackChange);
            if (company == null) NotFound();

            var employee = _repositoryManager.Employee.GetEmployee(CompanyId, Id, trackChange);
            if (employee == null) NotFound();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }
    }
}
