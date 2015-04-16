using FluentMigrator;

namespace MunkeyIssues.Migrations._2015._04
{
    [Tags("Production", "Integration")]
    [Migration(20150415153705)]
    public class Migration201504151537_AddSaltColumnToUsersTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Column("Salt").OnTable("Users").AsString(255).NotNullable();
        }
    }
}