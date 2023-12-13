using System;
using System.ComponentModel.DataAnnotations;
using CmcMarkets.Backend.Core.Enums;

namespace CmcMarkets.Backend.Core.Entities
{
    public class UserTask
    {
        [Key]
        public Guid UserTaskId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public TaskStatusEnum TaskStatus { get; set; }

        [Required]
        public DateTime CreatedAtUtc { get; set; }
    }
}
