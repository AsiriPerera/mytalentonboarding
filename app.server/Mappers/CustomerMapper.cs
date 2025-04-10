using app.server.Dtos;
using app.server.Models;

namespace app.server.Mappers
{
    public class CustomerMapper
    {
        public static CustomerDto EntityToDto(Customer customer)
        {
            var dto = new CustomerDto 
            { 
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address
            };
            return dto;
        }
        public static Customer DtoToEntity(CustomerDto customerDto)
        {
            var entity = new Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Address = customerDto.Address
            };
            return entity;
        }
    }
}
