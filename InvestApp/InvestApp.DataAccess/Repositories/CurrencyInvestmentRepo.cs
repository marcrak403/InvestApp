using AutoMapper;
using InvestApp.Core.Constants;
using InvestApp.DataAccess.Dtos;
using InvestApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestApp.DataAccess.Repositories
{
    public class CurrencyInvestmentRepo : ICurrencyInvestmentRepo
    {
        private readonly InvestAppDbContext _context;
        private readonly IMapper _mapper;

        public CurrencyInvestmentRepo(InvestAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddCurrencyInvestment(AddCurrencyInvestmentDto addCurrencyInvestmentDto)
        {
            if (addCurrencyInvestmentDto != null)
            {
                _context.CurrencyInvestments.Add(_mapper.Map<CurrencyInvestment>(addCurrencyInvestmentDto));
                var totalAmount = await _context.TotalAmountOfCurrencies
                    .FirstOrDefaultAsync(p => p.Currency == addCurrencyInvestmentDto.CurrencyType
                    && p.AssignedToId == addCurrencyInvestmentDto.AssignedToId);

                if (totalAmount != null)
                {
                    totalAmount.TotalAmount += addCurrencyInvestmentDto.Amount;
                    totalAmount.InvestedMoney += addCurrencyInvestmentDto.Amount * Convert.ToDouble(addCurrencyInvestmentDto.ExchangeRate);
                }
                else
                {
                    _context.TotalAmountOfCurrencies.Add(new TotalAmountOfCurrency()
                    {
                        Currency = addCurrencyInvestmentDto.CurrencyType,
                        TotalAmount = addCurrencyInvestmentDto.Amount,
                        InvestedMoney = addCurrencyInvestmentDto.Amount * Convert.ToDouble(addCurrencyInvestmentDto.ExchangeRate),
                        AssignedToId = addCurrencyInvestmentDto.AssignedToId
                    });
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task SellCurrency(int userId, Currencies currency, int amount)
        {
           if (await _context.TotalAmountOfCurrencies.FirstOrDefaultAsync(p => p.AssignedToId == userId 
            && p.Currency == currency) is not
                TotalAmountOfCurrency totalAmountOfCurrency || totalAmountOfCurrency.TotalAmount < amount)
            {
                return;
            }
            totalAmountOfCurrency.TotalAmount -= amount;

            if(totalAmountOfCurrency.TotalAmount == 0)
            {
                _context.TotalAmountOfCurrencies.Remove(totalAmountOfCurrency);
            }

            await _context.SaveChangesAsync();
        }
    }
}
