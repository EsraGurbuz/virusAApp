using System;
using System.Collections.Generic;
using virusAApp.Models;

namespace virusAApp.Interfaces
{
    public interface IAntiVirusService
    {
        // Starts scanning the system (Regedit / Files)
        void StartScan();

        // Stops the active scanning process
        void StopScan();

        // Cleans/Removes a specific detected threat from the system
        bool EliminateThreat(VirusThreat threat);

        // Returns the list of currently detected threats
        List<VirusThreat> GetDetectedThreats();
    }
}