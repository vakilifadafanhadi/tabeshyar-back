using System.Collections.Generic;
using tabeshyar_back.Models;
using tabeshyar_back.ModelViews;

namespace tabeshyar_back.Repositories
{
    public interface ISmsOutboxRepository
    {
        Task<SmsOutbox> CreateAsync(SmsOutboxDto inbox);
        Task<List<SmsOutboxDto>> GetPaginationAsync(int pageNumber,int take);
        Task<int> CountAsync();
    }
}
