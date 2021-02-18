using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latite
{
    class Data
    {
        public static bool DataLoaded = false;

        #region data
        #region mods
        public struct Zoom
        {
            public static bool Enabled;
            public static byte Amount;
            public static char Bind;
        }

        public struct ToggleSprint
        {
            public static bool Enabled = false;
            public static char Bind = '\0';
            public static int Anchor = 0;
            public static int[] Position = { 0, 0 };
        }

        public struct LookBehind
        {
            public static bool Enabled = false;
            public static char Bind = '\0';
        }

        public struct Fullbright
        {
            public static bool Enabled = false;
        }

        public struct TimeChanger
        {
            public static bool Enabled = false;
            public static int TimeOfDay = 0;
        }

        #endregion mods
        #region options
        public struct Options
        {
            public static double Opacity = 1.0;
        }
        #endregion options
        #region overlay

        public struct Keystrokes
        {
            public static int Anchor = 0;
            public static byte[] RGB = { 0, 0, 0 };
            public static bool Enabled = false;
            public static int[] Position = { 0, 0 };
        }

        public struct PosDisplay
        {
            public static bool Enabled = false;
            public static int Anchor = 0;
            public static int[] Position = { 0, 0, 0 };
        }

        public struct BlockPosDisplay
        {
            public static bool Enabled = false;
            public static int Anchor = 0;
            public static int[] Position = { 0, 0, 0 };
        }

        #endregion overlay
        #endregion data

        public static bool ReadRgb(byte[] List)
        {
            bool p = true;
            List[0] = Storage.NextByte(out p);
            List[1] = Storage.NextByte(out p);
            List[2] = Storage.NextByte(out p);
            return p;
        }

        public static bool ReadPosition(int[] List)
        {
            bool p = true;
            List[0] = Storage.NextInt(out p);
            List[1] = Storage.NextInt(out p);
            return p;
        }

        public static bool ReadBool()
        {
            bool x = false;
            return Storage.NextByte(out x) == 1;
        }

        public static bool Load()
        {
            Storage.Clear();

            // Decode binary stream
            bool Success = true;
            Zoom.Enabled = Storage.NextByte(out Success) == 1;
            if (!Success) return false;
            Zoom.Bind = (char)Storage.NextByte(out Success);

            // ------ Mods ------

            ToggleSprint.Enabled = ReadBool();
            ToggleSprint.Anchor = Storage.NextInt(out Success);
            ReadPosition(ToggleSprint.Position);

            LookBehind.Enabled = ReadBool();
            LookBehind.Bind = (char)Storage.NextByte(out Success);

            TimeChanger.Enabled = ReadBool();
            TimeChanger.TimeOfDay = Storage.NextInt(out Success);

            // ------ Options ------

            Options.Opacity = Storage.NextDouble(out Success);

            // ------ Overlay ------

            PosDisplay.Enabled = ReadBool();
            PosDisplay.Anchor = Storage.NextInt(out Success);
            ReadPosition(PosDisplay.Position);

            BlockPosDisplay.Enabled = ReadBool();
            BlockPosDisplay.Anchor = Storage.NextInt(out Success);
            ReadPosition(BlockPosDisplay.Position);

            Keystrokes.Enabled = ReadBool();
            Keystrokes.Anchor = Storage.NextInt(out Success);
            ReadPosition(Keystrokes.Position);

            return true;
        }

        public static void SetBool(bool val)
        {
            Storage.InsertByte(Convert.ToByte(val));
        }

        public static bool SetPosition(int[] pos)
        {
            bool p = true;
            Storage.InsertInt(pos[0]);
            Storage.InsertInt(pos[1]);
            return p;
        }

        public static void Unload()
        {
            Storage.Clear();

            // Decode binary stream
            SetBool(Zoom.Enabled);
            Storage.InsertByte((byte)Zoom.Bind);

            // ------ Mods ------

            SetBool(ToggleSprint.Enabled);
            Storage.InsertInt(ToggleSprint.Anchor);
            SetPosition(ToggleSprint.Position);

            SetBool(LookBehind.Enabled);
            Storage.InsertByte((byte)LookBehind.Bind);

            SetBool(TimeChanger.Enabled);
            Storage.InsertInt(TimeChanger.TimeOfDay);

            // ------ Options ------

            Storage.InsertDouble(Options.Opacity);

            // ------ Overlay ------

            Data.SetBool(PosDisplay.Enabled);
            Storage.InsertInt(PosDisplay.Anchor);
            ReadPosition(PosDisplay.Position);

            SetBool(BlockPosDisplay.Enabled);
            Storage.InsertInt(BlockPosDisplay.Anchor);
            SetPosition(BlockPosDisplay.Position);

            SetBool(Keystrokes.Enabled);
            Storage.InsertInt(Keystrokes.Anchor);
            SetPosition(Keystrokes.Position);
        }
    }
}
