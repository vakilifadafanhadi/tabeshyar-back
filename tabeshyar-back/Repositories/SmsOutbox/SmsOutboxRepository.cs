using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tabeshyar_back.Models;
using tabeshyar_back.ModelViews;

namespace tabeshyar_back.Repositories
{
    public class SmsOutboxRepository : RepositoryBase<SmsOutbox>, ISmsOutboxRepository
    {
        public SmsOutboxRepository(TabeshyarDb repositoryContext, IMapper mapper) : base(repositoryContext, mapper)
        {
        }
        public async Task<SmsOutbox> CreateAsync(SmsOutboxDto smsInbox)
        {
            var result = _mapper.Map<SmsOutbox>(smsInbox);
            await CreateAsync(result);
            return result;
        }
        public async Task<List<SmsOutboxDto>> GetPaginationAsync(int pageNumber, int take)
        {
            return await GetByQuery()
                .Select(current => _mapper.Map<SmsOutboxDto>(current))
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
