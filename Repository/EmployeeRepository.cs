using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Employee> GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
             await  FindByCondition(d => d.CompanyId.Equals(companyId) && d.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public async Task<IEnumerable<Employee>> GetEmployees(Guid companyId, bool trackChanges) =>
            FindByCondition(d => d.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name);
     
    }
}
