using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pms.Application.Dtos.Api;
using Pms.Application.Commands.OnlinePayment.AccountDeposit;

namespace Pms.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<AccountDepositRequest, AccountDepositCommand>();



        }
    }
}
