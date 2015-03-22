using System;
using System.Collections.Generic;
using MunkeyIssues.Core.Domain;

namespace MunkeyService.IssueService.Domain
{
    public class Issue : IEntity 
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int AssignedToId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedById { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int LaneId { get; set; }

        public int PriorityId { get; set; }

        public Priority Priority { get; set; }

        public int ProjectId { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public ICollection<Tag> Tags { get; set; } 
    }
}
