﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MunkeyIssues.IssueService.Domain;

namespace MunkeyIssues.IssueService.Persistence.Mappings
{
    public class PriorityMapping : EntityTypeConfiguration<Priority>
    {
        public PriorityMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("PriorityId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.IsDefault);
            Property(p => p.IsDeleted);
            Property(p => p.Name);
        }
    }
}