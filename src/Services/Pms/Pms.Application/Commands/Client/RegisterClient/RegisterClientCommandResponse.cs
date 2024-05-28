using Pms.Domain.Common.Enums;
using SharedKernel.Common;

namespace Pms.Application.Commands.Client.RegisterClient;

public class RegisterClientCommandResponse : BaseCommandResponse
{
    public Guid ClientUxId { get; }


    public RegisterClientCommandResponse(bool succeed, Guid clientUxId, ErrorCodes? errorCode = null) : base(succeed, errorCode)
    {
        ClientUxId = clientUxId;
    }
}