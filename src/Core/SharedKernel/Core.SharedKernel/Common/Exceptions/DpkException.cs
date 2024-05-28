namespace SharedKernel.Common.Exceptions
{
    public class DpkException : Exception
    {
        private readonly string _customMessage;

        public DpkException(string customerMessage,Exception innerException):base(customerMessage,innerException){}

        public DpkException(string customerMessage):base(customerMessage)
        {
        }
    }
}
