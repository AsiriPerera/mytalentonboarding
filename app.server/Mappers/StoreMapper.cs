using app.server.Dtos;
using app.server.Models;

namespace app.server.Mappers
{
    public class StoreMapper
    {
        public static StoreDto EntityToDto(Store store)
        {
            var dto = new StoreDto
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address
            };
            return dto;
        }
        public static Store DtoToEntity(StoreDto storeDto)
        {
            var entity = new Store
            {
                Id = storeDto.Id,
                Name = storeDto.Name,
                Address = storeDto.Address
            };
            return entity;
        }
    }
}
