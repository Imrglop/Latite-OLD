using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Latite
{
	class Storage
	{
		[DllImport("LatiteCore.dll", EntryPoint = "SilverNextInt")]
		public static extern int NextInt(out bool status);
		[DllImport("LatiteCore.dll", EntryPoint = "SilverNextByte")]
		public static extern byte NextByte(out bool status);
		[DllImport("LatiteCore.dll", EntryPoint = "SilverNextDouble")]
		public static extern double NextDouble(out bool status);
		[DllImport("LatiteCore.dll", EntryPoint = "SilverClear")]
		public static extern void Clear();
		[DllImport("LatiteCore.dll", EntryPoint = "SilverJump")]
		public static extern void Jump(uint pos = 1);
		[DllImport("LatiteCore.dll", EntryPoint = "SilverInsertInt")]
		public static extern void InsertInt(int val);
		[DllImport("LatiteCore.dll", EntryPoint = "SilverInsertByte")]
		public static extern void InsertByte(byte val);
		[DllImport("LatiteCore.dll", EntryPoint = "SilverInsertDouble")]
		public static extern void InsertDouble(double val);
		[DllImport("LatiteCore.dll", EntryPoint = "SilverGetFileSize")]
		public static extern ulong GetFileSize();
	}
}
