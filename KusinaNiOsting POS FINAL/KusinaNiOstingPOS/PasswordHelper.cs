using System.Security.Cryptography;
using System.Text;

namespace MiniMartPOS
{
    internal static class PasswordHelper
    {
        internal static string Hash(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.Unicode.GetBytes(password));
                StringBuilder hash = new StringBuilder();
                foreach (byte b in bytes) hash.Append(b.ToString("X2"));
                return hash.ToString();
            }
        }
    }
}
