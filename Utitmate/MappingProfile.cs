using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Utitmate
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Company, CompanyDto>
                ().ForMember(m => m.FullAddress,
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();

        }
    }
}
