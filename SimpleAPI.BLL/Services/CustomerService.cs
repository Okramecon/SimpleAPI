using AutoMapper;
using SimpleAPI.BLL.Contracts;
using SimpleAPI.BLL.Helpers;
using SimpleAPI.DAL.Contracts;
using SimpleAPI.DAL.Entities;
using SimpleAPI.DTO.CustomerDTOs;

namespace SimpleAPI.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private IEntityRepository<Customer> _customerRepository;
        private IMapper _mapper;

        public CustomerService(IEntityRepository<Customer> repositry, IMapper mapper)
        {
            _customerRepository = repositry;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CustomerAddDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);

            await _customerRepository.AddAsync(customerEntity);
            await _customerRepository.SaveChangesAsync();

            return customerEntity.Id;
        }

        public async Task<CustomerGetDto> GetByIdAsync(int id)
        {
            var entity = await _customerRepository.GetByIdAsync(id, false);

            if (entity is null)
                throw new Exception("Entity with given id does not exist");

            return _mapper.Map<CustomerGetDto>(entity);
        }
    }
}
