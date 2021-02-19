using System;
using System.Windows.Forms;

namespace Latite
{
    class Data
    {

        public static readonly int LatestFormatVersion = 1;
        public static int FormatVersion = 1;

        #region data
        #region mods

        public struct Zoom
        {
            public static bool Enabled = true;
            public static byte Amount = 7;
            public static byte Bind = (byte)'C';
        }

        public struct ToggleSprint
        {
            public static bool Enabled = false;
            public static byte Bind = 0xA2;
            public static int Anchor = (int)(AnchorStyles.Left | AnchorStyles.Bottom);
            public static int[] Position = { 16, 688 };
        }

        public struct LookBehind
        {
            public static bool Enabled = true;
            public static byte Bind = (byte)'G';
        }

        public struct Fullbright
        {
            public static bool Enabled = false;
        }

        public struct TimeChanger
        {
            public static bool Enabled = false;
            public static int TimeOfDay = 1;
        }

        #endregion mods
        #region options
        public struct Options
        {
            public static int Opacity = 20;
        }
        #endregion options
        #region overlay

        public struct Keystrokes
        {
            public static int Anchor = (int)(AnchorStyles.Top | AnchorStyles.Left);
            public static byte[] RGB = { 255, 255, 255 };
            public static bool Enabled = true;
            public static int[] Position = { 14, 14 };
        }

        public struct PosDisplay
        {
            public static bool Enabled = true;
            public static int Anchor = (int)AnchorStyles.Left;
            public static int[] Position = { 14, 367 };
        }

        public struct BlockPosDisplay
        {
            public static bool Enabled = false;
            public static int Anchor = (int)(AnchorStyles.Bottom | AnchorStyles.Left);
            public static int[] Position = { 17, 590 };
        }

        #endregion overlay
        #endregion data
        #region utils

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
        #endregion utils

        public static bool Load()
        {
            Storage.Clear();

            // Decode binary stream
            bool Success = false;
            //Data.FormatVersion = Storage.NextInt(out Success);
            byte nb = Storage.NextByte(out Success);
            ulong FileSize = Storage.GetFileSize();
            if (FileSize == 0) return false;
            #region FIXME
            /*if (FormatVersion != LatestFormatVersion)
            {
                // Outdated
                var Result = MessageBox.Show($"The saved data didn't load, {(FormatVersion < LatestFormatVersion ? "outdated" : "too new")} format version: {FormatVersion}. The current format version is {LatestFormatVersion}.\nThis means you downgrated or upgraded Latite, or corrupted 'data.bin'.\nPress retry to reset data to default.\nPress cancel to ignore this (not recommended!)",
                    "Data Corruption Warning", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (Result == DialogResult.Retry)
                {
                    System.IO.File.Delete("data.bin");
                    Data.FormatVersion = LatestFormatVersion;
                    Data.Save(true);
                    Data.Load();
                }
            }*/
            #endregion FIXME
            Zoom.Enabled = nb == 1;
            byte tc = Storage.NextByte(out Success);
            Zoom.Bind = tc;
            Zoom.Amount = Storage.NextByte(out Success);

            // ------ Mods ------

            ToggleSprint.Enabled = ReadBool();
            ToggleSprint.Anchor = Storage.NextInt(out Success);
            ReadPosition(ToggleSprint.Position);

            LookBehind.Enabled = ReadBool();
            LookBehind.Bind = Storage.NextByte(out Success);

            TimeChanger.Enabled = ReadBool();
            //TimeChanger.TimeOfDay = Storage.NextInt(out Success);

            // ------ Options ------

            Options.Opacity = Storage.NextInt(out Success);

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
            ReadRgb(Keystrokes.RGB);

            return true;
        }

        #region sutils
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

        public static bool SetRgb(byte[] rgb)
        {
            bool p = true;
            Storage.InsertByte(rgb[0]);
            Storage.InsertByte(rgb[1]);
            Storage.InsertByte(rgb[2]);
            return p;
        }
        #endregion sutils
        public static void Save(bool FirstSave = false)
        {
            Storage.Clear();

            // Decode binary stream
            //Storage.InsertInt(FirstSave ? Data.LatestFormatVersion : Data.FormatVersion);
            SetBool(Zoom.Enabled);
            Storage.InsertByte(Zoom.Bind);
            Storage.InsertByte(Zoom.Amount);

            // ------ Mods ------

            SetBool(ToggleSprint.Enabled);
            Storage.InsertInt(ToggleSprint.Anchor);
            SetPosition(ToggleSprint.Position);

            SetBool(LookBehind.Enabled);
            Storage.InsertByte(LookBehind.Bind);

            SetBool(TimeChanger.Enabled);
            //Storage.InsertInt(TimeChanger.TimeOfDay);

            // ------ Options ------

            Storage.InsertInt(Options.Opacity);

            // ------ Overlay ------

            Data.SetBool(PosDisplay.Enabled);
            Storage.InsertInt(PosDisplay.Anchor);
            SetPosition(PosDisplay.Position);

            SetBool(BlockPosDisplay.Enabled);
            Storage.InsertInt(BlockPosDisplay.Anchor);
            SetPosition(BlockPosDisplay.Position);

            SetBool(Keystrokes.Enabled);
            Storage.InsertInt(Keystrokes.Anchor);
            SetPosition(Keystrokes.Position);
            SetRgb(Keystrokes.RGB);
        }
    }
}
