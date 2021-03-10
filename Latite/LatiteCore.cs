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
            public static extern float getYMotion();

            [DllImport("LatiteCore.dll", EntryPoint = "LPGetPos")]
            public static extern IntPtr getPosition(); // float[3]
            [DllImport("LatiteCore.dll", EntryPoint = "LPGetMotion")]
            public static extern float getMotion();
            [DllImport("LatiteCore.dll", EntryPoint = "LPGetLookAtBlock")]
            public static extern IntPtr getLookAtBlock();
        }
        [DllImport("LatiteCore.dll")]
        public static extern void mod_freelook_setBind(char bind);
    }
}
