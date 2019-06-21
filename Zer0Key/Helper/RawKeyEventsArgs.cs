using System;
using System.Windows.Input;

namespace Zer0Key
{
    public delegate void RawKeyEventHandler(object sender, RawKeyEventArgs args);

    public class RawKeyEventArgs : EventArgs
    {
        #region Member
        public int VKCode;
        public Key Key;
        public bool IsSysKey;
        #endregion

        #region Constructor
        public RawKeyEventArgs(int vkCode, bool isSysKey)
        {
            VKCode = vkCode;
            IsSysKey = isSysKey;
            Key = KeyInterop.KeyFromVirtualKey(VKCode);
        }
        #endregion
    }
}
