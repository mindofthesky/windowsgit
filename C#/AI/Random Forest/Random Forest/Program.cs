// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
double answer = 0;
double n = 121;

for(double i = 0; i<=n; i++)
{
    if (Math.Pow(i, 2) == n) answer += Math.Pow(i + 1, 2);
    else answer = - 1;
}