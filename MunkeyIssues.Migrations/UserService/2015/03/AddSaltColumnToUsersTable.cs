using FluentMigrator;

namespace MunkeyIssues.Migrations.UserService._2015._03
{
    [Tags("Production", "Integration")]
    [Migration(20150331085701)]
    public class AddSaltColumnToUsersTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Column("Salt").OnTable("Users").AsString(255).NotNullable();
        }
    }
}