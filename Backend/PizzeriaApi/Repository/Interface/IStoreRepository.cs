using PizzeriaApi.DTO;

namespace PizzeriaApi.Repository.Interface
{
    public interface IStoreRepository
    {
        Task<List<StoreDTO>> GetStoreList();
        Task<StoreDTO> GetStore(int storeId);
        Task<ApiResponse> SaveStore(StoreDTO store);
        Task<ApiResponse> DeleteStore(int storeId);
    }
}
