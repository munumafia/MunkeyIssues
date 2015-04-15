using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunkeyIssues.Core.Messaging.Users.Auth;
using MunkeyIssues.Core.Messaging.Users.Register;
using MunkeyIssues.UserService.Mappers;
using MunkeyIssues.UserService.Mappers.User;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.UserService.StructureMap.Registries
{
    public class MapperRegistry : Registry
    {
        public MapperRegistry()
        {
            var cryptoKey = ConfigurationManager.AppSettings["CryptoKey"];
            
            For<IMapper<RegisterUserRequest, Domain.User>>().Use<RegisterUserRequestToUserMapper>()
                .Ctor<string>("privateKey").Is(cryptoKey);

            For<IMapper<AuthenticateRequest, Domain.User>>().Use<AuthenticateRequestToUserMapper>()
                .Ctor<string>("privateKey").Is(cryptoKey);
        }
    }
}
