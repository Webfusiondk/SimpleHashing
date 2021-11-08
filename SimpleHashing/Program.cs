using SimpleHashing;
using System.Diagnostics;
using System.Text;

RandomNumberGenerator rng = new RandomNumberGenerator();
Console.WriteLine("Welcome to simple Hash");
Console.WriteLine("Pleas insert the text you want to hash");
ChoseAlgorithm(Console.ReadLine());


void ChoseAlgorithm(string text)
{
    Console.WriteLine("1: Hash");
    Console.WriteLine("2: HMAC");
    string userinput = Console.ReadLine();
    switch (userinput)
    {
        case "1":
            Console.Clear();
            HashText(text);
            break;
        case "2":
            Console.Clear();
            HMACText(text);
            break;
        default:
            Console.WriteLine("Wrong input");
            break;
    }
}

byte[] ChoseHash(string text)
{
    Console.WriteLine("1: MD5");
    Console.WriteLine("2: SHA256");
    string userinput = Console.ReadLine();
    switch (userinput)
    {
        case "1":
            Console.Clear();
            Hash hashMD5 = new Hash();
            return hashMD5.HashMD5(Encoding.UTF8.GetBytes(text));
        case "2":
            Console.Clear();
            Hash hashSHA256 = new Hash();
            return hashSHA256.HashSha256(Encoding.UTF8.GetBytes(text));
        default:
            Console.WriteLine("Wrong input");
            return null;
    }
}

byte[] ChoseHMAC(string text, byte[] key)
{
    Console.WriteLine("1: HMD5");
    Console.WriteLine("2: HSHA256");
    string userinput = Console.ReadLine();
    switch (userinput)
    {
        case "1":
            Console.Clear();
            HMAC HMD5 = new HMAC();
            return HMD5.HMACMD5(Encoding.UTF8.GetBytes(text),key);
        case "2":
            Console.Clear();
            HMAC HSHA256 = new HMAC();
            return HSHA256.HMACSHA256(Encoding.UTF8.GetBytes(text),key);
        default:
            Console.WriteLine("Wrong input");
            return null;
    }
}

void HashText(string text)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    byte[] temp = ChoseHash(text);
    stopwatch.Stop();
    TimeSpan ts = stopwatch.Elapsed;
    Console.WriteLine($"RunTime in millisecounds: {ts.TotalMilliseconds}");
    Console.WriteLine($"Plain text: {Convert.ToBase64String(temp)}");
    Console.WriteLine($"Hex: {BitConverter.ToString(temp)}");
}

void HMACText(string text)
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    byte[] key = rng.GenerateKey();
    byte[] temp = ChoseHMAC(text,key);
    stopwatch.Stop();
    TimeSpan ts = stopwatch.Elapsed;
    Console.WriteLine($"RunTime in millisecounds: {ts.TotalMilliseconds}");
    Console.WriteLine($"Key: {Convert.ToBase64String(key)}");
    Console.WriteLine($"Plain text: {Convert.ToBase64String(temp)}");
    Console.WriteLine($"Hex: {BitConverter.ToString(temp)}");
}