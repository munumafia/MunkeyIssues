using System;
using System.Collections.Generic;
using FluentMigrator;
using MunkeyIssues.Migrations.Enums;
using MunkeyIssues.Migrations.Extensions;

namespace MunkeyIssues.Migrations._2015._04
{
    [Migration(20150415160745)]
    [Tags("Production", "Integration")]
    public class Migration201504151607_SeedData : Migration
    {
        public override void Up()
        {
            Insert.IntoTable(Tables.Categories).Rows(new List<object>()
            {
                new {Name = "Issue", IsDefault = true}, 
                new {Name = "Task", IsDefault = false}
            });

            Insert.IntoTable(Tables.Statuses).Rows(new List<object>()
            {
                new {Name = "Open", IsDefault = true, IsOpen = true},
                new {Name = "Closed", IsDefault = false, IsOpen = false},
                new {Name = "Wont Fix", IsDefault = false, IsOpen = false}
            });

            Insert.IntoTable(Tables.Priorities).Rows(new List<object>()
            {
                new {Name = "Low", DefaultDisplayOrder = 1, IsDefault = false},
                new {Name = "Normal", DefaultDisplayOrder = 2, IsDefault = true},
                new {Name = "High", DefaultDisplayOrder = 3, IsDefault = false}
            });
        }

        public override void Down()
        {
            // Nothing to roll back
        }
    }
}
