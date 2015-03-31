using MunkeyIssues.UserService.AutoMapper;
using Topshelf;

namespace MunkeyIssues.UserService
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperBuilder.Build();

            HostFactory.Run(x =>
            {
                x.Service<UserService>(s =>
                {
                    s.ConstructUsing(obj => new UserService());
                    s.WhenStarted(obj => obj.Start());
                    s.WhenStopped(obj => obj.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("User microservice for MunkeyIssues");
                x.SetDisplayName("MunkeyIssues User microservice");
                x.SetServiceName("MunkeyIssuesUserService");
            });
        }
    }
}
