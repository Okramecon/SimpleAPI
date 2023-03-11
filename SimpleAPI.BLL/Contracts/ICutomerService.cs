using SimpleAPI.DTO.CustomerDTOs;

namespace SimpleAPI.BLL.Contracts
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(CustomerAddDto customer);
        Task<CustomerGetDto> GetByIdAsync(int id);
    }
}
