using Entities.identity;
using System.Threading.Tasks;

namespace Services.Api.Contract
{
    public interface IjwtService
    {
        Task<string> GenerateTokenAsync(User User);
    }
}
