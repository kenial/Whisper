using System;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Whisper.Properties;

namespace Whisper
{
    public partial class PreferenceForm : Form
    {
        public PreferenceForm(Form owner)
        {
            Owner = owner;
            InitializeComponent();
        }

        private void PreferenceForm_Load(object sender, EventArgs e)
        {
            SpeechSynthesizer speechObject = ((MainForm)Owner).GetSpeechSynthesizer();
            foreach (InstalledVoice installedVoice in speechObject.GetInstalledVoices())
            {
                VoiceComboBox.Items.Add(installedVoice.VoiceInfo.Name);
            }
            VoiceComboBox.Text = Settings.Default.SelectedVoice;
            SpeakVolumeTrackBar.Value = Settings.Default.SelectedSpeakVolume;
            SpeakRateTrackBar.Value = Settings.Default.SelectedSpeakRate;
        }

        private void ApplyChangedSpeakSettings()
        {
            Settings.Default.Save();
            ((MainForm)Owner).ApplyChangedSpeakSettings();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/kenial/Whisper");
        }

        private void VoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.SelectedVoice = VoiceComboBox.Text;
            ApplyChangedSpeakSettings();
        }

        private void SpeakVolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.Default.SelectedSpeakVolume = SpeakVolumeTrackBar.Value;
            ApplyChangedSpeakSettings();
        }

        private void SpeakRateTrackBar_Scroll(object sender, EventArgs e)
        {
            Settings.Default.SelectedSpeakRate = SpeakRateTrackBar.Value;
            ApplyChangedSpeakSettings();
        }
    }
}
