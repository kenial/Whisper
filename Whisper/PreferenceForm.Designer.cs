using System;
using System.Drawing;
using System.Windows.Forms;

namespace Whisper
{
    partial class PreferenceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VoiceComboBox = new System.Windows.Forms.ComboBox();
            this.SpeakVolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeakRateTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakVolumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakRateTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // VoiceComboBox
            // 
            this.VoiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VoiceComboBox.FormattingEnabled = true;
            this.VoiceComboBox.Location = new System.Drawing.Point(87, 13);
            this.VoiceComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VoiceComboBox.Name = "VoiceComboBox";
            this.VoiceComboBox.Size = new System.Drawing.Size(331, 28);
            this.VoiceComboBox.TabIndex = 1;
            this.VoiceComboBox.SelectedIndexChanged += new System.EventHandler(this.VoiceComboBox_SelectedIndexChanged);
            // 
            // SpeakVolumeTrackBar
            // 
            this.SpeakVolumeTrackBar.LargeChange = 20;
            this.SpeakVolumeTrackBar.Location = new System.Drawing.Point(82, 70);
            this.SpeakVolumeTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpeakVolumeTrackBar.Maximum = 100;
            this.SpeakVolumeTrackBar.Name = "SpeakVolumeTrackBar";
            this.SpeakVolumeTrackBar.Size = new System.Drawing.Size(336, 69);
            this.SpeakVolumeTrackBar.SmallChange = 5;
            this.SpeakVolumeTrackBar.TabIndex = 5;
            this.SpeakVolumeTrackBar.TickFrequency = 5;
            this.SpeakVolumeTrackBar.Scroll += new System.EventHandler(this.SpeakVolumeTrackBar_Scroll);
            // 
            // SpeakRateTrackBar
            // 
            this.SpeakRateTrackBar.LargeChange = 2;
            this.SpeakRateTrackBar.Location = new System.Drawing.Point(82, 133);
            this.SpeakRateTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SpeakRateTrackBar.Minimum = -10;
            this.SpeakRateTrackBar.Name = "SpeakRateTrackBar";
            this.SpeakRateTrackBar.Size = new System.Drawing.Size(336, 69);
            this.SpeakRateTrackBar.TabIndex = 6;
            this.SpeakRateTrackBar.Value = -10;
            this.SpeakRateTrackBar.Scroll += new System.EventHandler(this.SpeakRateTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Voice";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Volume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Speed";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(273, 223);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(145, 20);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "";
            this.linkLabel1.Text = "Click to Github Link";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // PreferenceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(436, 264);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpeakRateTrackBar);
            this.Controls.Add(this.SpeakVolumeTrackBar);
            this.Controls.Add(this.VoiceComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PreferenceForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Preference";
            this.Load += new System.EventHandler(this.PreferenceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpeakVolumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeakRateTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ComboBox VoiceComboBox;
        public TrackBar SpeakVolumeTrackBar;
        public TrackBar SpeakRateTrackBar;
        private Label label1;
        private Label label2;
        private Label label3;
        private LinkLabel linkLabel1;
    }
}