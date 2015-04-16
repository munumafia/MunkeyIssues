using System;
using FluentMigrator.Builders.Create;
using FluentMigrator.Builders.Create.Table;
using MunkeyIssues.Migrations.Enums;

namespace MunkeyIssues.Migrations.Extensions
{
    public static class CreateExtensions
    {
        public static ICreateTableWithColumnOrSchemaOrDescriptionSyntax Table(this ICreateExpressionRoot create, Tables table)
        {
            var tableName = Enum.GetName(typeof (Tables), table);
            return create.Table(tableName);
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(this ICreateTableWithColumnSyntax table,
            string columnName)
        {
            return table.WithColumn(columnName).AsInt32().NotNullable().PrimaryKey().Identity();
        }
    }
}
