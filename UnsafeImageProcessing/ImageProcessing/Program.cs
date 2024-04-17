// See https://aka.ms/new-console-template for more information
using ImageProcessing;
using System.Diagnostics;
using System.Drawing;

Console.WriteLine("_____How fast could be you code if you are working with pointer_______");

string imageFilePath =Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)+ "\\..\\..\\..\\..\\" + "Lenna_(test_image).bmp";

var timesOfRepeating = 100;

Stopwatch timer = new Stopwatch();

Bitmap bmp=Processor.LoadBitmap(imageFilePath);

byte[,,] byteArray;

timer.Start();
for (var i = 0; i < timesOfRepeating; i++)
{
    byteArray = Processor.BitmapToByteRgbNaive(bmp);
}
timer.Stop();
Console.WriteLine($"1. Time converting bmp to bitmap array without pointers (ms) - {timer.ElapsedMilliseconds}");

timer.Restart();
for (var i = 0; i < timesOfRepeating; i++)
{
    byteArray = Processor.BitmapToByteRgb(bmp);
}
timer.Stop();
Console.WriteLine($"2. Time converting bmp to bitmap array with pointers (ms) - {timer.ElapsedMilliseconds}");

timer.Restart();
for (var i = 0; i < timesOfRepeating; i++)
{
    byteArray = Processor.BitmapToByteRgbQ(bmp);
}
timer.Stop();
Console.WriteLine($"3. Time converting bmp to bitmap array with pointers (with enhancement) (ms) - {timer.ElapsedMilliseconds}");

Console.ReadLine();