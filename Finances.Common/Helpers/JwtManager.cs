using Finances.Common.Data;
using Finances.Common.Interfaces;
using Finances.Common.Session;
using Jose;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Finances.Common.Helpers
{
    public class JwtManager : IJwtManager
    {
        private readonly AppSettings Configuration;

        private static string secretPhrase;

        public JwtManager(AppSettings configuration)
        {
            Configuration = configuration;
            secretPhrase = Configuration.JwtSecret;
        }

        public string GenerateToken<T>(T viewModel)
        {
            byte[] key = Encoding.ASCII.GetBytes(secretPhrase);
            string token = JWT.Encode(viewModel, key, JwsAlgorithm.HS256);
            return token;
        }
        
        public LoginJwt DecodeToken(string token)
        {
            byte[] secretInBytes = Encoding.ASCII.GetBytes(secretPhrase);
            string tokenDecoded = JWT.Decode(token, secretInBytes);
            return JsonConvert.DeserializeObject<LoginJwt>(tokenDecoded);
        }
        
        //public static void CancelToken(string token, DatabaseContext context)
        //{
        //    var jwt = context.login_jwt
        //    .Where(j => j.id == token)
        //    .SingleOrDefault();

        //    jwt.status = Status.Inactive;
        //    jwt.expire_date = DateTime.Now;

        //    context.login_jwt.Add(jwt);
        //    context.SaveChanges();
        //}
    }
    
}
