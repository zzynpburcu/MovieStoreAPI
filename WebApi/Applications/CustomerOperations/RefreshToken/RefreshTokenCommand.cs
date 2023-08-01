using WebApi.DBOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi.Applications.CustomerOperations.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration mapper)
        {
            _dbContext = dbContext;
            _configuration = mapper;
        }

        public Token Handle()
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.RefresToken == RefreshToken && x.RefreshTokenExpDate > DateTime.Now);
            if (customer !=null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccesToken(customer);

                customer.RefresToken = token.RefreshToken;
                customer.RefreshTokenExpDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;

            }
            else
            {
                throw new InvalidOperationException("Valid bir refresh token bulunamadı !");
            }
        }


    }
}