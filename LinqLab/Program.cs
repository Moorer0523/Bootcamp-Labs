int[] nums = { 10, 2330, 112233, 12, 949, 3764, 2942, 523863 };

Console.WriteLine("Writing the minimum value");
Console.WriteLine(nums.Min());

Console.WriteLine("Writing the maximum value");
Console.WriteLine(nums.Max());

Console.WriteLine("Writing all the values less than 10000");
Console.WriteLine(nums.Where(num => num < 10000).Max());

Console.WriteLine("Writing all the values between 10 and 100");
Console.WriteLine(string.Join(' ', nums.Where(num => num > 10 && num < 100).ToList()));

Console.WriteLine("Writing all the values between 100000 and 999999, including those numbers");
Console.WriteLine(string.Join(' ',nums.Where(num => num >= 100_000 && num <= 999_999).ToList()));

Console.WriteLine("Writing the number of even numbers");
Console.WriteLine(nums.Where(num => num % 2 == 0).Count());



