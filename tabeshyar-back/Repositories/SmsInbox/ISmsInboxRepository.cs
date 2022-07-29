using tabeshyar_back.Models;
using tabeshyar_back.ModelViews;
namespace tabeshyar_back.Repositories
{
    public interface ISmsInboxRepository
    {
        Task<SmsInbox> CreateAsync(SmsInboxDto inbox);
        Task<List<string>> GetContactsAsync();
        Task<List<SmsInboxDto>> GetPaginationAsync(int pageNumber,int take);
        Task<int> CountAsync();
    }
}
