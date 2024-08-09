<Query Kind="Program" />

using System;

static int Main(string args){
int x = 12 * 30;
Console.WriteLine(x);

Console.WriteLine(FeetToInches(30));
Console.WriteLine(FeetToInches(100));	

int i =1_000_000;
Console.WriteLine(i);	


int i1 = 100000001;
float f = i1; // Magnitude preserved, precision lost
Console.WriteLine(f);	

int i2 = (int)f; // 100000000
Console.WriteLine(i2);	

Console.WriteLine("\n ***int.MinValue***");
int a = int.MinValue; a--;
Console.WriteLine (int.MinValue);
Console.WriteLine (a);
Console.WriteLine (a == int.MaxValue); // True

Console.WriteLine("\n ***checked/unchecker***");
int a1= 1000000, b = 1000000;

int c = checked (a * b);

checked // Checks all expressions
{ // in statement block
	c = a * b;
}

return 0;
}

static int FeetToInches (int feet)
{
int inches = feet * 12;
return inches;
}
// You can define other methods, fields, classes and namespaces here
