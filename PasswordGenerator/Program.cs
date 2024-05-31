using System.Security.Cryptography;

Console.Write("Bytes lenght: ");
var length = Convert.ToInt32(Console.ReadLine());

var bytes = RandomNumberGenerator.GetBytes(length);
var password = Convert.ToBase64String(bytes);

Console.WriteLine(password);