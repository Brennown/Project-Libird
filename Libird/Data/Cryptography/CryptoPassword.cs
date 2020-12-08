using System.Security.Cryptography;
using System.Text;

namespace Libird.Data.Cryptography
{
    public static class CryptoPassword
    {
        public static string HashMD5(string password)
        {
            var bytes = Encoding.ASCII.GetBytes(password);
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(bytes);

            var ret = string.Empty;
            for (int i = 0; i < hash.Length; i++)
            {
                ret += hash[i].ToString("x2");
            }

            return ret;
        }
    }
}
