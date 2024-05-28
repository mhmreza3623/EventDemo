using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Pms.Application.Commands.Authenticate.VerifyToken
{
    public class VerifyTokenCommand:IRequest<VerifyTokenCommandResponse>
    {
        public string Token { get; set; }
    }
}
