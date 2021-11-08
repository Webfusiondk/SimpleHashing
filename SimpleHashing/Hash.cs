using System.Security.Cryptography;
namespace SimpleHashing
{
    internal class Hash
    {
        //Hash the data we get.
        public byte[] HashMD5(byte[] toBeHashed)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(toBeHashed);
            }
        }
        public byte[] HashSha256(byte[] toBeHashed)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }
    }
}
