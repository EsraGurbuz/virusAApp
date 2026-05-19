namespace virusAApp.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStartScan = new Button();
            btnStopScan = new Button();
            lblStatus = new Label();
            lstThreats = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            SuspendLayout();
            // 
            // btnStartScan
            // 
            btnStartScan.Location = new Point(12, 316);
            btnStartScan.Name = "btnStartScan";
            btnStartScan.Size = new Size(94, 29);
            btnStartScan.TabIndex = 0;
            btnStartScan.Text = "Start Scan";
            btnStartScan.UseVisualStyleBackColor = true;
            btnStartScan.Click += btnStartScan_Click;
            // 
            // btnStopScan
            // 
            btnStopScan.Location = new Point(12, 351);
            btnStopScan.Name = "btnStopScan";
            btnStopScan.Size = new Size(94, 29);
            btnStopScan.TabIndex = 1;
            btnStopScan.Text = "Stop Scan";
            btnStopScan.UseVisualStyleBackColor = true;
            btnStopScan.Click += btnStopScan_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 394);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(97, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status: Ready";
            //lblStatus.Click += label1_Click;
            // 
            // lstThreats
            // 
            lstThreats.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lstThreats.Location = new Point(12, 27);
            lstThreats.Name = "lstThreats";
            lstThreats.Size = new Size(556, 269);
            lstThreats.TabIndex = 3;
            lstThreats.UseCompatibleStateImageBehavior = false;
            lstThreats.View = View.Details;
            //lstThreats.SelectedIndexChanged += lstThreats_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Threat Name";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Registry Path";
            columnHeader2.TextAlign = HorizontalAlignment.Right;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstThreats);
            Controls.Add(lblStatus);
            Controls.Add(btnStopScan);
            Controls.Add(btnStartScan);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartScan;
        private Button btnStopScan;
        private Label lblStatus;
        private ListView lstThreats;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}
