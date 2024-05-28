namespace SharedKernel.Identities
{
    public class JwtModel
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Secret { get; set; }
    }
}
