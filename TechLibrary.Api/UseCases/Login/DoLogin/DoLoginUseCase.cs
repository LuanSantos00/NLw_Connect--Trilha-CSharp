using TechLibrary.Api.Infraestructure.DataAccess;
using TechLibrary.Api.Infraestructure.Security.Cryptography;
using TechLibrary.Api.Infraestructure.Security.Tokens.Access;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.UseCases.Login.DoLogin
{
    public class DoLoginUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {
            var dbContext = new TechLibraryDbContext();

            var user = dbContext.Users.FirstOrDefault(user => user.Email.Equals(request.Email));
            if (user is null)
                throw new InvalidLoginException();

            var criptography = new BCryptAlgorithm();
            var passwordIsValid = criptography.Verify(request.Password, user);
            if (passwordIsValid is false)
                throw new InvalidLoginException();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                AccessToken = tokenGenerator.Generate(user)
            };
        }
    }
}
