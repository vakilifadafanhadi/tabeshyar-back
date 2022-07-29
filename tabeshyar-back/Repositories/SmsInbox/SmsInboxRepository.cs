using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using tabeshyar_back.Models;
using tabeshyar_back.ModelViews;
namespace tabeshyar_back.Repositories
{
    public class SmsInboxRepository : RepositoryBase<SmsInbox>, ISmsInboxRepository
    {
        public SmsInboxRepository(TabeshyarDb repositoryContext, IMapper mapper):base(repositoryContext, mapper)
        {
        }
        public async Task<SmsInbox> CreateAsync(SmsInboxDto smsInbox)
        {
            var result = _mapper.Map<SmsInbox>(smsInbox);
            await CreateAsync(result);
            return result;
        }
        public async Task<List<SmsInboxDto>> GetPaginationAsync(int pageNumber, int take)
        {
            return await GetByQuery()
                .Select(x => _mapper.Map<SmsInboxDto>(x))
                .Skip((pageNumber - 1) * take)
                .Take(take)
                .ToListAsync();
        }
        public async Task<List<string>> GetContactsAsync()
        {
            return await GetByQuery()
                .Where(x => !string.IsNullOrEmpty(x.From))
                .Select(x=>x.From)
                .Distinct()
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await GetByQuery()
                .CountAsync();
        }
    }
}
