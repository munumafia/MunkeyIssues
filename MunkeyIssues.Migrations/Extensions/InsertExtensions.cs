using System;
using System.Collections;
using System.Collections.Generic;
using FluentMigrator.Builders.Insert;
using MunkeyIssues.Migrations.Enums;

namespace MunkeyIssues.Migrations.Extensions
{
    public static class InsertExtensions
    {
        public static IInsertDataOrInSchemaSyntax IntoTable(this IInsertExpressionRoot insert, Tables table)
        {
            var tableName = Enum.GetName(typeof (Tables), table);
            return insert.IntoTable(tableName);
        }

        public static IInsertDataSyntax Rows(this IInsertDataOrInSchemaSyntax table, IList<object> rows)
        {
            IInsertDataSyntax row = null;

            foreach (var entry in rows)
            {
                row = row == null ? table.Row(entry) : row.Row(entry);
            }

            return row;
        }
    }
}
