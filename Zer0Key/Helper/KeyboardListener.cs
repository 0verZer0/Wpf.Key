using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Zer0Key
{

    public class KeyboardListener : IDisposable
    {
        #region Member
        public static IntPtr hookId = IntPtr.Zero;
        private static LowLevelKeyboardProc callBack;
        #endregion

        #region Event
        public event RawKeyEventHandler KeyDown;
        public event RawKeyEventHandler KeyUp;
        #endregion

        #region Contructor/ Destructor
        public KeyboardListener()
        {
            callBack = (LowLevelKeyboardProc)HookCallback;
            hookId = InterceptKeys.SetHook(callBack);
        }

        ~KeyboardListener()
        {
            Dispose();
        }
        #endregion

        #region Method
        [MethodImpl(MethodImplOptions.NoInlining)]
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                return HookCallbackInner(nCode, wParam, lParam);
            }
            catch
            { }

            return InterceptKeys.CallNextHookEx(hookId, nCode, wParam, lParam);
        }
        private IntPtr HookCallbackInner(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (wParam == (IntPtr)InterceptKeys.WM_KEYDOWN || wParam == (IntPtr)InterceptKeys.WM_SYS_KEYDOWN)
                    KeyDown?.Invoke(this, new RawKeyEventArgs(vkCode, false));
                else if (wParam == (IntPtr)InterceptKeys.WM_KEYUP || wParam == (IntPtr)InterceptKeys.WM_SYS_KEYUP)
                    KeyUp?.Invoke(this, new RawKeyEventArgs(vkCode, false));
            }

            return InterceptKeys.CallNextHookEx(hookId, nCode, wParam, lParam);
        }
        public void Dispose()
        {
            InterceptKeys.UnhookWindowsHookEx(hookId);
        }
        #endregion
    }
}