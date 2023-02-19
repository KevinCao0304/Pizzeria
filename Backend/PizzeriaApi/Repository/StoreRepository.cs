using Microsoft.EntityFrameworkCore;
using PizzeriaApi.DTO;
using PizzeriaApi.Models;
using PizzeriaApi.Repository.Interface;
using System.Reflection.Metadata;

namespace PizzeriaApi.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StoreRepository (IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ApiResponse> DeleteStore(int storeId)
        {
            ApiResponse deleteResponse = new ApiResponse();
            try
            {
                var storeDB = _repositoryWrapper.Store.GetBy(x => x.Id == storeId).FirstOrDefault();
                if (storeDB != null)
                {
                    _repositoryWrapper.Store.Delete(storeDB);
                }
                await _repositoryWrapper.Store.SaveChangesAsync();

                return deleteResponse;
            }
            catch (Exception ex)
            {
                deleteResponse.ResponseMessage = ex.Message;
                return deleteResponse;
            }
        }

        public async Task<StoreDTO> GetStore(int storeId)
        {
            var query = _repositoryWrapper.Store.GetBy(x=>x.Id==storeId).Select(obj =>
                        new StoreDTO
                        {
                            Id = obj.Id,
                            StoreName = obj.StoreName,
                            Location = obj.Location
                        });
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<StoreDTO>> GetStoreList()
        {
            var query = _repositoryWrapper.Store.GetAll().Select(obj =>
                        new StoreDTO
                        {
                            Id = obj.Id,
                            StoreName = obj.StoreName,
                            Location = obj.Location
                        });
            return query.ToList();
        }

        public async Task<ApiResponse> SaveStore(StoreDTO store)
        {
            ApiResponse saveResponse = new ApiResponse();
            try
            {
                var storeDB = _repositoryWrapper.Store.GetBy(x => x.Id == store.Id).FirstOrDefault();
                if (storeDB != null)
                {
                    storeDB.StoreName = store.StoreName;
                    storeDB.Location = store.Location;
                    _repositoryWrapper.Store.Edit(storeDB);
                }
                else
                {
                    storeDB = _repositoryWrapper.Store.Add(
                        new Store()
                        {
                            Location = store.Location,
                            StoreName = store.StoreName
                        }
                    );
                }
                await _repositoryWrapper.Store.SaveChangesAsync();
                saveResponse.ResponseKey = storeDB.Id;
                return saveResponse;
            }
            catch(Exception ex)
            {
                saveResponse.ResponseMessage = ex.Message;
                return saveResponse;
            }

        }
    }
}
