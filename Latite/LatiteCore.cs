using System;
using System.Runtime.InteropServices;

namespace Latite
{
    class LatiteCore
    {
        [DllImport("LatiteCore.dll")]
        public static extern void setEnabled(uint modId, bool enabled);
        [DllImport("LatiteCore.dll")]
        public static extern void consoleMain();
        [DllImport("LatiteCore.dll")]
        public static extern uint attach();
        [DllImport("LatiteCore.dll")]
        public static extern bool connectedToMinecraft(int type = 2);
        [DllImport("LatiteCore.dll")]
        public static extern void detach();
        [DllImport("LatiteCore.dll")]
        public static extern void loop();

        [DllImport("LatiteCore.dll")]
        public static extern void mod_zoom_setBind(char bind);
        [DllImport("LatiteCore.dll")]
        public static extern void mod_zoom_setAmount(float amount);
        [DllImport("LatiteCore.dll")]
        public static extern void mod_lookBehind_setBind(char bind);
        [DllImport("LatiteCore.dll")]
        public static extern void setTimeChangerSetting(int setting);

        [DllImport("LatiteCore.dll")]
        public static extern void settingsConfigSet(string k, string v);
        [DllImport("LatiteCore.dll")]
        public static extern int getCurrentGui();

        public struct LocalPlayer
        {
            [DllImport("LatiteCore.dll", EntryPoint = "LPGetYMotion")]
            public static extern float GetYMotion();
            [DllImport("LatiteCore.dll", EntryPoint = "LPGetXPos")]
            public static extern float GetXPos();
            [DllImport("LatiteCore.dll", EntryPoint = "LPGetYPos")]
            public static extern float GetYPos();
            [DllImport("LatiteCore.dll", EntryPoint = "LPGetZPos")]
            public static extern float GetZPos();
            [DllImport("LatiteCore.dll", EntryPoint = "LPGetMotion")]
            public static extern float GetMotion();
            [DllImport("LatiteCore.dll", EntryPoint = "LPGetLookAtBlock")]
            public static extern IntPtr GetLookAtBlock();
        }
        [DllImport("LatiteCore.dll")]
        public static extern void mod_freelook_setBind(char bind);
    }
}
