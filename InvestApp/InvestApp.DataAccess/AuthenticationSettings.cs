namespace InvestApp
{
    public class AuthenticationSettings
    {
        public string? JwtKey { get; set; }
        public int DurationInMinutes { get; set; }
        public string? JwtIssuer { get; set; }
    }
}
