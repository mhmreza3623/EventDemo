using Pms.Domain.Common.Enums;

namespace Pms.Application.Commands
{
    public class BaseCommandResponse
    {
        public BaseCommandResponse(bool succeed, ErrorCodes? errorCode = null)
        {
            Succeed = succeed;
            ErrorCode = errorCode;
        }

        public bool Succeed { get; }
        public ErrorCodes? ErrorCode { get; }

    }
}
