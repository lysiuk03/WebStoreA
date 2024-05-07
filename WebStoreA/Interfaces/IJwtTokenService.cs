using WebStoreA.Data.Entities.Identity;

namespace WebStoreA.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateToken(UserEntity user);
    }
}
