﻿namespace ChequeProcessingSystem.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        public string Action { get; set; } = string.Empty; // e.g., "Cheque Approved"

        public string UserId { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public string Details { get; set; } = string.Empty;
    }
}
