using Microsoft.EntityFrameworkCore;
using tabeshyar_back.Models;
namespace tabeshyar_back
{
    public class TabeshyarDb:DbContext
    {
        public TabeshyarDb(DbContextOptions<TabeshyarDb> options):base(options)
        {
        }
        public DbSet<SmsOutbox> SmsOutboxes { get; set; }
        public DbSet<SmsInbox> SmsInboxes { get; set; }
        public DbSet<LatteryCode> LatteryCodes { get; set; }
    }
}
