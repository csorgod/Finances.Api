using Finances.Common.Session;

namespace Finances.Common.Interfaces
{
    public interface IJwtManager
    {
        string GenerateToken<T>(T viewModel);

        LoginJwt DecodeToken(string token);
    }
}
