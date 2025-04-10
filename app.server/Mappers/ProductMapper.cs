using app.server.Dtos;
using app.server.Models;

namespace app.server.Mappers
{
    public class ProductMapper
    {
        public static ProductDto EntityToDto(Product product)
        {
            var dto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
            return dto;
        }
        public static Product DtoToEntity(ProductDto productDto)
        {
            var entity = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price
            };
            return entity;
        }
    }
}
