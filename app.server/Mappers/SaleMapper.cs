using app.server.Dtos;
using app.server.Models;

namespace app.server.Mappers
{
    public class SaleMapper
    {
        public static SaleDto EntityToDto(Sale sale)
        {
            var dto = new SaleDto
            {
                Id = sale.Id,
                ProductId = sale.ProductId,
                CustomerId = sale.CustomerId,
                StoreId = sale.StoreId,
                DateSold = sale.DateSold
            };
            return dto;
        }
        public static Sale DtoToEntity(SaleDto saleDto)
        {
            var entity = new Sale
            {
                Id = saleDto.Id,
                ProductId = saleDto.ProductId,
                CustomerId = saleDto.CustomerId,
                StoreId = saleDto.StoreId,
                DateSold = saleDto.DateSold
            };
            return entity;
        }
    }
}
