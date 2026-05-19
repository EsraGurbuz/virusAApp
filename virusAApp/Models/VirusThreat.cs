using System;

namespace virusAApp.Models
{
    public class VirusThreat
    {
        // Unique identifier for each detected threat
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // Name of the virus or suspicious activity
        public string Name { get; set; }

        // Registry path or File path where the threat is located
        public string Path { get; set; }

        // Danger level of the threat
        public ThreatSeverity Severity { get; set; }

        // Time when the threat was detected
        public DateTime DetectionTime { get; set; } = DateTime.Now;

        // Status of the threat (e.g., Active, Quarantined, Deleted)
        public string Status { get; set; } = "Active";
    }
}