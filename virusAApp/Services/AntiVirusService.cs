using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using virusAApp.Interfaces;
using virusAApp.Models;

namespace virusAApp.Services
{
    public class AntiVirusService : IAntiVirusService
    {
        private readonly List<VirusThreat> _detectedThreats;
        private bool _isScanning;

        // Events to notify the UI without tight coupling
        public event Action<VirusThreat> OnThreatDetected;
        public event Action<string> OnScanStatusChanged;

        public AntiVirusService()
        {
            _detectedThreats = new List<VirusThreat>();
            _isScanning = false;
        }

        public void StartScan()
        {
            if (_isScanning) return;

            _isScanning = true;
            _detectedThreats.Clear();
            OnScanStatusChanged?.Invoke("Scan started... Analyzing Registry and System paths.");

            // Simulating an asynchronous scan using a background Task
            Task.Run(() =>
            {
                SimulateRegistryScan();
            });
        }

        public void StopScan()
        {
            if (!_isScanning) return;

            _isScanning = false;
            OnScanStatusChanged?.Invoke("Scan cancelled by the user.");
        }

        public bool EliminateThreat(VirusThreat threat)
        {
            // Simulating threat removal
            var target = _detectedThreats.Find(t => t.Id == threat.Id);
            if (target != null)
            {
                target.Status = "Cleaned/Removed";
                OnScanStatusChanged?.Invoke($"Threat '{threat.Name}' has been successfully eliminated from Registry.");
                return true;
            }
            return false;
        }

        public List<VirusThreat> GetDetectedThreats()
        {
            return _detectedThreats;
        }

        private void SimulateRegistryScan()
        {
            // Mock data simulating typical registry malware startup keys
            var mockRegistryLocations = new List<VirusThreat>
            {
                new VirusThreat { Name = "Trojan.Win32.RegRun.a", Path = @"HKCU\Software\Microsoft\Windows\CurrentVersion\Run\SuspiciousUpdate", Severity = ThreatSeverity.Critical },
                new VirusThreat { Name = "Adware.Registry.Optimizer", Path = @"HKLM\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Run\FakeSpeedUp", Severity = ThreatSeverity.Medium },
                new VirusThreat { Name = "Spyware.Keylogger.Active", Path = @"HKCU\Software\Microsoft\Windows\CurrentVersion\Run\WinLogs", Severity = ThreatSeverity.High }
            };

            foreach (var threat in mockRegistryLocations)
            {
                if (!_isScanning) break;

                // Simulate a delay for realistic scanning illusion
                Thread.Sleep(1500);

                _detectedThreats.Add(threat);
                // Trigger the event to inform UI immediately
                OnThreatDetected?.Invoke(threat);
            }

            if (_isScanning)
            {
                _isScanning = false;
                OnScanStatusChanged?.Invoke($"Scan completed. Total threats found: {_detectedThreats.Count}");
            }
        }
    }
}