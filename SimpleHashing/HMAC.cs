using System.Security.Cryptography;

namespace SimpleHashing
{
    internal class HMAC
    {

        //HMAC the data we get.
        public byte[] HMACMD5(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }

        public byte[] HMACSHA256(byte[] toBeHashed, byte[] key)
        {
            using (var hmac = new HMACMD5(key))
            {
                return hmac.ComputeHash(toBeHashed);
            }
        }
    }
}
