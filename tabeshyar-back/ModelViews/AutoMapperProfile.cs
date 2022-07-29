using AutoMapper;
using tabeshyar_back.Models;

namespace tabeshyar_back.ModelViews
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SmsInbox, SmsInboxDto>().ReverseMap();
            CreateMap<SmsOutbox, SmsOutboxDto>().ReverseMap();
            CreateMap<LatteryCode, LatteryCodeDto>().ReverseMap();
        }
    }
}
