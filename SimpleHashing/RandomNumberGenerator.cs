using System.Security.Cryptography;

namespace SimpleHashing
{
    internal class RandomNumberGenerator
    {
        //Generate a random number that we use as key
        public byte[] GenerateKey()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[32];
                rng.GetBytes(data);

                return data;
            };
        }
    }
}
