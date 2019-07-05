
using System;
using System.Windows.Forms;

namespace Whisper
{
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            this._modifier = modifier;
            this._key = key;
        }

        public ModifierKeys Modifier
        {
            get
            {
                return this._modifier;
            }
        }

        public Keys Key
        {
            get
            {
                return this._key;
            }
        }
    }
}
