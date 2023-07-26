using API.Resources;

namespace API.Services
{
    public interface IUserService
    {
        List<FruitVegesOutput> GetFruitVeges();
        Task<List<ExpectedOutput>> GetExpectedOutput();
    }
}
