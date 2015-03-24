using Topshelf;

namespace MunkeyIssues.IssueService
{
    class Program
    {
        static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<IssueService>(s =>
                {
                    s.ConstructUsing(obj => new IssueService());
                    s.WhenStarted(obj => obj.Start());
                    s.WhenStopped(obj => obj.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Issues microservice for MunkeyIssues");
                x.SetDisplayName("MunkeyIssues Issues microservice");
                x.SetServiceName("MunkeyIssuesIssuesService");
            });
        }
    }
}
