using System.Configuration;
using MunkeyIssues.Core.Services.Cryptography;
using MunkeyIssues.UserService.Domain;
using MunkeyIssues.UserService.Service.User;
using MunkeyIssues.UserService.Service.User.Validation;
using MunkeyIssues.UserService.Service.Validation;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.UserService.StructureMap.Registries
{
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            var key = ConfigurationManager.AppSettings["CryptoKey"];
            For<IEncryptionService>().Use<RSAEncryptionService>().Ctor<string>(key);

            For<IValidateAdd<User>>().Use<UserAddValidator>();
            For<IUserService>().Use<Service.User.UserService>();
            For<IHashService>().Use<SHA512HashService>();
        }
    }
}
