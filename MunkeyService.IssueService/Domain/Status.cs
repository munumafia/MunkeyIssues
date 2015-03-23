﻿using MunkeyIssues.Core.Domain;

namespace MunkeyIssues.IssueService.Domain
{
    public class Status : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsDefault { get; set; }
    }
}
