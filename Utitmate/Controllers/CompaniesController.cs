using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Utitmate.Controllers
{
    [Route("api/Companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CompaniesController(IRepositoryManager repositoryManager, IMapper mapper) {
            _repositoryManager = repositoryManager;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies() {
         
                var companies = await _repositoryManager.Company.GetAllCompanies(trackChanges: false);
                var payload = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return Ok(payload);
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetSingleCompanyById(Guid id)
        {
            var company = await _repositoryManager.Company.GetCompanyById(id, trackChanges: false);
            if(company != null)
            {
                var mapper = _mapper.Map<CompanyDto>(company);
                return Ok(mapper);
            }
            else
            {
                return NotFound();
            }
        } 


    }
}
