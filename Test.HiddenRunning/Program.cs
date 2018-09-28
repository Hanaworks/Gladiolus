using System
	; 

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hanaworks.Gladiolus.Tools;

namespace Test.HiddenRunning
{
	class Program
	{
		static void Main(string[] args)
		{
			var startInfo = new ProcessStartInfo()
			{
				FileName = @"E:\scrds\CSS\srcds.exe",
				Arguments = "-game cstrike +map de_dust2 -maxplayers 32 +sv_lan 0 -insecure -console -port 27018",
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true
			};

			var process = Process.Start(startInfo);
			process.OutputDataReceived += Process_OutputDataReceived;
			//process.ErrorDataReceived += Process_ErrorDataReceived;

			process.BeginOutputReadLine();
			//process.BeginErrorReadLine();

			Thread.Sleep(1000);
			var result =  Win32Api.ShowWindow(process.MainWindowHandle, 0);
			
			Debug.Assert(result);

			//while (true)
			//{
			//	var cmd = Console.ReadLine();
			//	process.StandardInput.WriteLine(cmd);
			//}

			process.WaitForExit();
		}

		private static void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
		}

		private static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
		}
	}
}
