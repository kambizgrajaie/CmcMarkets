using CmcMarkets.Backend.Core.Enums;
using System;

namespace CmcMarkets.Backend.Core.Dto
{
    public class UserTaskDto
    {
        public Guid UserTaskId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
