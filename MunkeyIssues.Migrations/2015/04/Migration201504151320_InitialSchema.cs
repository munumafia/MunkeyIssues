using FluentMigrator;
using MunkeyIssues.Migrations.Enums;
using MunkeyIssues.Migrations.Extensions;

namespace MunkeyIssues.Migrations._2015._04
{
    [Migration(20150415132040)]
    [Tags("Production", "Integration")]
    public class Migration201504151320_InitialSchema : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table(Tables.Users)
                .WithIdColumn("UserID")
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable()
                .WithColumn("EmailAddress").AsString(255).NotNullable().Unique()
                .WithColumn("Password").AsString(255).NotNullable()
                .WithColumn("IsDisabled").AsBoolean().NotNullable().WithDefaultValue(false);

            Create.Table(Tables.Clients)
                .WithIdColumn("ClientID")
                .WithColumn("Name").AsString(255).NotNullable().Unique()
                .WithColumn("IsDefault").AsBoolean().NotNullable().WithDefaultValue(false);

            Create.Table(Tables.Tags)
                .WithIdColumn("TagID")
                .WithColumn("Name").AsString(255).NotNullable().Unique();

            Create.Table(Tables.Statuses)
                .WithIdColumn("StatusID")
                .WithColumn("Name").AsString(255).NotNullable().Unique()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsDefault").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsOpen").AsBoolean().NotNullable().WithDefaultValue(false);

            Create.Table(Tables.Categories)
                .WithIdColumn("CategoryID")
                .WithColumn("Name").AsString(255).NotNullable().Unique()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsDefault").AsBoolean().NotNullable().WithDefaultValue(false);

            Create.Table(Tables.Priorities)
                .WithIdColumn("PriorityID")
                .WithColumn("Name").AsString(255).NotNullable().Unique()
                .WithColumn("DefaultDisplayOrder").AsInt32().NotNullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsDefault").AsBoolean().NotNullable().WithDefaultValue(false);
            
            Create.Table(Tables.Projects)
                .WithIdColumn("ProjectID")
                .WithColumn("Name").AsString(255).NotNullable().Unique()
                .WithColumn("Description").AsString(int.MaxValue).Nullable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false);

            Create.Table(Tables.PriorityProject)
                .WithColumn("PriorityID").AsInt32().NotNullable().ForeignKey("Priorities", "PriorityID")
                .WithColumn("ProjectID").AsInt32().NotNullable().ForeignKey("Projects", "ProjectID")
                .WithColumn("DisplayOrder").AsInt32().NotNullable().Unique();
            
            Create.Table(Tables.StatusProject)
                .WithColumn("StatusID").AsInt32().NotNullable().ForeignKey("Statuses", "StatusID")
                .WithColumn("ProjectID").AsInt32().NotNullable().ForeignKey("Projects", "ProjectID");

            Create.Table(Tables.CategoryProject)
                .WithColumn("CategoryID").AsInt32().NotNullable().ForeignKey("Categories", "CategoryID")
                .WithColumn("ProjectID").AsInt32().NotNullable().ForeignKey("Projects", "ProjectID");

            Create.Table(Tables.ClientProject)
                .WithColumn("ClientID").AsInt32().NotNullable().ForeignKey("Clients", "ClientID")
                .WithColumn("ProjectID").AsInt32().NotNullable().ForeignKey("Projects", "ProjectID");

            Create.Table(Tables.UserProject)
                .WithIdColumn("UserID")
                .WithColumn("ProjectID").AsInt32().NotNullable().ForeignKey("Projects", "ProjectID");    

            Create.Table(Tables.Issues)
                .WithIdColumn("IssueID")
                .WithColumn("Title").AsString(255).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).Nullable()
                .WithColumn("AssignedToID").AsInt32().NotNullable().ForeignKey("Users", "UserID")
                .WithColumn("ClientID").AsInt32().Nullable().ForeignKey("Clients", "ClientID")
                .WithColumn("CreatedOn").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("CreatedBy").AsInt32().NotNullable().ForeignKey("Users", "UserID")
                .WithColumn("CategoryID").AsInt32().NotNullable().ForeignKey("Categories", "CategoryID")
                .WithColumn("PriorityID").AsInt32().NotNullable().ForeignKey("Priorities", "PriorityID")
                .WithColumn("ProjectID").AsInt32().NotNullable().ForeignKey("Projects", "ProjectID")
                .WithColumn("StatusID").AsInt32().NotNullable().ForeignKey("Statuses", "StatusID")
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false);

            Create.Table(Tables.IssueTag)
                .WithColumn("IssueID").AsInt32().NotNullable().ForeignKey("Issues", "IssueID")
                .WithColumn("TagID").AsInt32().NotNullable().ForeignKey("Tags", "TagID");

            Create.Table(Tables.Boards)
                .WithIdColumn("BoardID")
                .WithColumn("Name").AsString(255).NotNullable().Unique()
                .WithColumn("ProjectID").AsInt32().NotNullable();

            Create.Table(Tables.Lanes)
                .WithIdColumn("LaneID")
                .WithColumn("BoardID").AsInt32().NotNullable().ForeignKey("Boards", "BoardID")
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("DisplayOrder").AsInt32().NotNullable();

            Create.Table(Tables.Card)
                .WithIdColumn("CardID")
                .WithColumn("IssueID").AsInt32().NotNullable().ForeignKey("Issues", "IssueID")
                .WithColumn("LaneID").AsInt32().NotNullable().ForeignKey("Lanes", "LaneID")
                .WithColumn("IsBlocked").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("LanePosition").AsInt32().NotNullable();
        }
    }
}