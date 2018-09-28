using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Hanaworks.Gladiolus.Tools
{
    public static class Win32Api
	{
		[DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
		public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
	}
}
