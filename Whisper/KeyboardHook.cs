using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Whisper
{
    public sealed class KeyboardHook : IDisposable
    {
        private KeyboardHook.Window _window = new KeyboardHook.Window();
        private int _currentId;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public KeyboardHook()
        {
            this._window.KeyPressed += (EventHandler<KeyPressedEventArgs>)((sender, args) =>
            {
                if (this.KeyPressed == null)
                    return;
                this.KeyPressed((object)this, args);
            });
        }

        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            ++this._currentId;
            if (!KeyboardHook.RegisterHotKey(this._window.Handle, this._currentId, (uint)modifier, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
        }

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public void Dispose()
        {
            for (int currentId = this._currentId; currentId > 0; --currentId)
                KeyboardHook.UnregisterHotKey(this._window.Handle, currentId);
            this._window.Dispose();
        }

        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 786;

            public Window()
            {
                this.CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg != KeyboardHook.Window.WM_HOTKEY)
                    return;
                Keys key = (Keys)((int)m.LParam >> 16 & (int)ushort.MaxValue);
                ModifierKeys modifier = (ModifierKeys)((int)m.LParam & (int)ushort.MaxValue);
                if (this.KeyPressed != null)
                    this.KeyPressed((object)this, new KeyPressedEventArgs(modifier, key));
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            public void Dispose()
            {
                this.DestroyHandle();
            }
        }
    }
}
