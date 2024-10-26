using System.Security.Cryptography;

var length = Convert.ToInt32(args.FirstOrDefault());
length = length < 6 ? 6 : length;

var bytes = RandomNumberGenerator.GetBytes(length);
var password = Convert.ToBase64String(bytes);

Console.WriteLine(password);
