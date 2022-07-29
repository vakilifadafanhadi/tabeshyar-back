using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using tabeshyar_back.Models;
using tabeshyar_back.ModelViews;

namespace tabeshyar_back.Repositories
{
    public class LatteryCodeRepository:RepositoryBase<LatteryCode>, ILatteryCodeRepository
    {
        public LatteryCodeRepository(TabeshyarDb repositoryContext, IMapper mapper) : base(repositoryContext, mapper)
        {
        }
        public async Task<List<LatteryCode>> CreateRangeAsync(List<LatteryCodeDto> latteryCodes)
        {
            var codes = _mapper.Map<List<LatteryCode>>(latteryCodes);
            await CreateRangeAsync(codes);
            return codes;
        }
        public async Task<LatteryCodeDto> FindByProductIdAsync(string productId)
        {
            var result = await GetByQuery()
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();
            return _mapper.Map<LatteryCodeDto>(result);
        }
        public async Task<LatteryCodeDto> UpdateAsync(LatteryCodeDto latteryCode)
        {
            var newLatteryCode = await UpdateAsync(latteryCode);
            return newLatteryCode;
        }
        public async Task<int> CountCurrentLatteryOwnersAsync(string latteryName)
        {
            return await GetByQuery()
                .Where(x=>x.LatteryName == latteryName)
                .Where(x=>! string.IsNullOrEmpty(x.Owner))
                .CountAsync();
        }
        public async Task<List<LatteryCodeDto>> GetPaginationAsync(int pageNumber, int take)
        {
            return await GetByQuery()
                .Select(current => _mapper.Map<LatteryCodeDto>(current))
                .Skip((pageNumber - 1) * take)
                .Take(take)
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await GetByQuery()
                .CountAsync();
        }
    }
}
