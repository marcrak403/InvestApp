using AutoMapper;
using InvestApp.DataAccess.Entities;
using InvestApp.DataAccess.Dtos;

namespace InvestApp.AutoMapper
{
    public class AutoMapper
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateUserDto, User>(MemberList.Destination);
            cfg.CreateMap<AddCurrencyInvestmentDto, CurrencyInvestment>(MemberList.Destination);
            cfg.CreateMap<AddMetalInvestmentDto, MetalInvestment>(MemberList.Destination);
        }
    }
}
