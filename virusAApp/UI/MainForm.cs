using System;
using System.Windows.Forms;
using virusAApp.Interfaces;
using virusAApp.Models;
using virusAApp.Services;

namespace virusAApp.UI
{
    public partial class MainForm : Form
    {
        // Depending on the abstraction, not the concrete implementation (Dependency Inversion principle)
        private readonly IAntiVirusService _antiVirusService;

        public MainForm()
        {
            InitializeComponent();

            // Set explicit English title for the professional look
            this.Text = "virusAApp - AntiVirus & Registry Scanner";

            lstThreats.Columns[0].Width = 200; // Width for "Threat Name" column
            lstThreats.Columns[1].Width = 350; // Width for "Registry Path" column

            // Instantiate the service (In a fully professional app, this would be injected via DI container)
            var concreteService = new AntiVirusService();
            _antiVirusService = concreteService;

            // Subscribe to the service events (Event-Driven architecture)
            concreteService.OnThreatDetected += Service_OnThreatDetected;
            concreteService.OnScanStatusChanged += Service_OnScanStatusChanged;
        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            lstThreats.Items.Clear();
            btnStartScan.Enabled = false;
            btnStopScan.Enabled = true;

            _antiVirusService.StartScan();
        }

        private void btnStopScan_Click(object sender, EventArgs e)
        {
            _antiVirusService.StopScan();
            btnStartScan.Enabled = true;
            btnStopScan.Enabled = false;
        }

        // Thread-safe UI update for scan status changes
        
        private void Service_OnScanStatusChanged(string statusMessage)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => Service_OnScanStatusChanged(statusMessage)));
                return;
            }

            lblStatus.Text = $"Status: {statusMessage}";

            if (statusMessage.Contains("completed") || statusMessage.Contains("cancelled"))
            {
                btnStartScan.Enabled = true;
                btnStopScan.Enabled = false;
            }
        }

        // Threat detection method with the correct VirusThreat parameter VirusThreat parametresine sahip tehdit yakalama metodu
        private void Service_OnThreatDetected(VirusThreat threat)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => Service_OnThreatDetected(threat)));
                return;
            }

            ListViewItem item = new ListViewItem(threat.Name);
            item.SubItems.Add(threat.Path);

            if (threat.Severity == ThreatSeverity.Critical || threat.Severity == ThreatSeverity.High)
            {
                item.ForeColor = System.Drawing.Color.Red;
            }

            lstThreats.Items.Add(item);
        }
    }
}
