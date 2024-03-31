namespace Aurora.Services
{
    public interface IAIService
    {
        Task<string> ProccessInput(string input);
    }
}