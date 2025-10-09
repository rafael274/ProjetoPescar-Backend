using System.Security.Cryptography;
using System.Text;

namespace controleEstoque.Domain.Extensions
{
    public static class Encrypt
    {
        public static string EncryptPassword(this string password)
        {
            if (string.IsNullOrEmpty(password))
                return null;

            password += "43baad43-4dcd-4c20-a7b5-db1992119c8d";
            var passwordTmp = password;
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(passwordTmp));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}        