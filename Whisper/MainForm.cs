using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Windows.Forms;
using Whisper.Properties;

namespace Whisper
{
    public partial class MainForm : Form
    {
        private SpeechSynthesizer _SpeechSynthesizer;
        private readonly KeyboardHook _KeyboardHook = new KeyboardHook();
        private const ModifierKeys DefaultModifierKeysSpeak = Whisper.ModifierKeys.Control;
        private const ModifierKeys DefaultModifierKeysSaveAudioFile = Whisper.ModifierKeys.Control | Whisper.ModifierKeys.Shift;
        private const Keys DefaultHotKey = Keys.Oemtilde;

        public MainForm()
        {
            InitializeComponent();
            _KeyboardHook.KeyPressed += KeyboardHook_HotKeyPressed;
            _KeyboardHook.RegisterHotKey(DefaultModifierKeysSpeak, DefaultHotKey);
            _KeyboardHook.RegisterHotKey(DefaultModifierKeysSaveAudioFile, DefaultHotKey);

            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
            NotifyIcon.Icon = (Icon)componentResourceManager.GetObject("WaitingIcon.Icon");
        }

        public SpeechSynthesizer GetSpeechSynthesizer()
        {
            if (_SpeechSynthesizer == null)
            {
                _SpeechSynthesizer = new SpeechSynthesizer();
                _SpeechSynthesizer.StateChanged += SpeechSynthesizer_StateChanged;
                ApplyChangedSpeakSettings();
            }
            return _SpeechSynthesizer;
        }

        public void ApplyChangedSpeakSettings()
        {
            SpeechSynthesizer speechObject = GetSpeechSynthesizer();
            if (Settings.Default.SelectedVoice == "")
            {
                Settings.Default.SelectedVoice = _SpeechSynthesizer.GetInstalledVoices().First().VoiceInfo.Name;
            }
            speechObject.SelectVoice(Settings.Default.SelectedVoice);
            speechObject.Volume = Settings.Default.SelectedSpeakVolume;
            speechObject.Rate = Settings.Default.SelectedSpeakRate;
        }

        private string GetSelectedText()
        {
            SendKeys.SendWait("^c");

            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
            {
                var selectedText = Clipboard.GetText(TextDataFormat.UnicodeText);
                Clipboard.Clear();
                return selectedText;
            }
            return "";
        }

        private void ShowPreferenceDialog()
        {
            PreferenceForm preferenceForm = new PreferenceForm((Form)this);
            preferenceForm.ShowDialog();
            preferenceForm.Dispose();
        }

        private string GetAvailableFilePath(string folderPath)
        {
            string path;
            int num = 0;
            do
            {
                ++num;
                path = $"{folderPath}\\Whispered_{num}.wav";
            }
            while (File.Exists(path));
            return path;
        }

        #region Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void KeyboardHook_HotKeyPressed(object sender, KeyPressedEventArgs e)
        {
            string textToSpeak = GetSelectedText();
            var speechSynthesizer = GetSpeechSynthesizer();
            if (e.Modifier == (Whisper.ModifierKeys.Control | Whisper.ModifierKeys.Shift))
            {
                SpeechAudioFormatInfo formatInfo = new SpeechAudioFormatInfo(EncodingFormat.ULaw, 22050, 8, 1, 64, 6, (byte[])null);
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string path = GetAvailableFilePath(folderPath);
                speechSynthesizer.SetOutputToWaveFile(path, formatInfo);
                speechSynthesizer.Speak(textToSpeak);
                speechSynthesizer.SetOutputToDefaultAudioDevice();
                speechSynthesizer.SpeakAsyncCancelAll();
            }
            else
            {
                speechSynthesizer.SpeakAsyncCancelAll();
                speechSynthesizer.SpeakAsync(textToSpeak);
            }
        }

        private void SpeechSynthesizer_StateChanged(object sender, StateChangedEventArgs e)
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));

            switch (e.State)
            {
                case SynthesizerState.Ready:
                    Text = "Whisper";
                    NotifyIcon.Icon = (Icon)componentResourceManager.GetObject("WaitingIcon.Icon");
                    break;
                case SynthesizerState.Speaking:
                    Text = "Whispering...";
                    NotifyIcon.Icon = ((System.Drawing.Icon)(componentResourceManager.GetObject("$this.Icon")));
                    break;
                case SynthesizerState.Paused:
                    Text = "Paused.";
                    break;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PreferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPreferenceDialog();
        }

        #endregion
    }
}
