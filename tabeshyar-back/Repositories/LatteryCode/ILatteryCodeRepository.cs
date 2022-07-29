using tabeshyar_back.Models;
using tabeshyar_back.ModelViews;

namespace tabeshyar_back.Repositories
{
    public interface ILatteryCodeRepository
    {
        Task<List<LatteryCode>> CreateRangeAsync(List<LatteryCodeDto> latteryCodes);
        Task<LatteryCodeDto> FindByProductIdAsync(string productId);
        Task<LatteryCodeDto> UpdateAsync(LatteryCodeDto latteryCode);
        Task<int> CountCurrentLatteryOwnersAsync(string latteryName);
        Task<List<LatteryCodeDto>> GetPaginationAsync(int pageNumber, int take);
        Task<int> CountAsync();
    }
}
