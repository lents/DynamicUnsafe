<Query Kind="Program" />

void Main()
{
	unsafe
	{
		Point point = new Point(0, 0);
		Console.WriteLine(point);   // X: 0  Y: 0
		Point* p = &point;

		p->X = 30;
		Console.WriteLine(p->X);    // 30

		// разыменовывание указателя
		(*p).Y = 180;
		Console.WriteLine((*p).Y);  // 180

		Console.WriteLine(point);   // X: 30  Y: 180
	}
}


struct Point
{
	public int X { get; set; }
	public int Y { get; set; }
	public Point(int x, int y)
	{
		X = x; Y = y;
	}
	public override string ToString() => $"X: {X}  Y: {Y}";
}
