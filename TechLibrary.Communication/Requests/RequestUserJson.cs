namespace TechLibrary.Communication.Requests
{
    public sealed class RequestUserJson
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
