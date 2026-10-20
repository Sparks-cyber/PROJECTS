using System.Security.Cryptography;
using System.Text;

namespace GROUP_PROJECT
{
    public static class PasswordSecurity
    {
        // Convert the password into a SHA-256 hash.
        public static string GetHashSha256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder hash = new StringBuilder();

                foreach (byte value in hashBytes)
                    hash.Append(value.ToString("x2"));

                return hash.ToString();
            }
        }
    }
}
