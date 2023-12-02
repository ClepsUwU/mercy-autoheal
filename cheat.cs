< Project Sdk = "Microsoft.NET.Sdk.WindowsDesktop" >


	< PropertyGroup >
		< OutputType > Exe </ OutputType >
		< TargetFramework > net6.0 - windows7global::System.Boolean v = .0 </ TargetFramework >
		< UseWPF > true </ UseWPF >
		< UseWindowsForms > true </ UseWindowsForms >
		< ImplicitUsings > enable </ ImplicitUsings >
		< Nullable > enable </ Nullable >
		< PlatformTarget > x86 </ PlatformTarget >
	</ PropertyGroup >


</ Project >;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using EZInput;
 
namespace CSS
{
	class Program
	{
		[DllImport("user32.dll")]
		static extern short GetAsyncKeyState(Keys Key);

		static bool hasExecuted = true;
		static bool Enabled = true;
		static System.Drawing.Point coordinates;

		static void Main(string[] args)
		{
			while (true)
			{
				Mercy();
			}

		}

		static System.Drawing.Color getColorAt(System.Drawing.Point coordinates)
		{
			using (Bitmap pixelContainer = new Bitmap(1, 1))
			{
				using (Graphics g = Graphics.FromImage(pixelContainer))
				{
					g.CopyFromScreen(coordinates, System.Drawing.Point.Empty, pixelContainer.Size);
				}
				return pixelContainer.GetPixel(0, 0);

			}
		}

		static void Mercy()
		{

			coordinates = new System.Drawing.Point(990, 715);
			var color = getColorAt(coordinates);
			var White = System.Drawing.Color.FromArgb(255, 255, 255, 255);

			var On = GetAsyncKeyState(Keys.F1); // turn on key
			var Off = GetAsyncKeyState(Keys.F2); // turn off key

			if (0 > On)
			{
				Enabled = true;
			}

			if (0 > Off)
			{
				Enabled = false;
			}


			if (Enabled == true)
			{
				if (color == White && hasExecuted == true)
				{
					//Console.WriteLine("damage boost");               
					Mouse.Click(MouseButton.Right);
					Thread.Sleep(700);
					hasExecuted = false;

				}


				if (color != White && hasExecuted == false)
				{
					//Console.WriteLine("heal");               
					Mouse.Click(MouseButton.Left);
					hasExecuted = true;
				}
			}


		}

	}

}