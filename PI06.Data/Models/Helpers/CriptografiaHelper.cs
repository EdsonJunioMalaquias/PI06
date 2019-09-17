using System.Security.Cryptography;
using System.Text;

namespace PI06.Helpers {
    public class CriptografiaHelper {
        public static byte[] CriptografarSenha (string senha) {
            return Criptografar (senha, "sfafsag-weqdsgdsg-aewrafa-421435");
        }

        public static byte[] Criptografar (string texto, string salt) {
            while (salt.Length < 6) {
                salt += salt + "Z";
            }
            using (var sha = SHA512.Create ()) {
                salt = Encoding.UTF8.GetString (sha.ComputeHash (Encoding.UTF8.GetBytes (salt.Substring (salt.Length - 4))));
                return sha.ComputeHash (Encoding.UTF8.GetBytes (texto + salt));
            }
        }
    }
}