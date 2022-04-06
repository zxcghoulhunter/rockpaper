using System;
using System.Security.Cryptography;
using System.Text;

namespace rockpaper
{
    class Hash
    {
        public static byte[] GenerateHMAC(string[] args, int computerMove, byte[] HMACKey)
        {
            byte[] HMAC = HMACHASH("Available moves: " + args[computerMove], HMACKey);
            return HMAC;
        }
        public static int GenerateComputerMove(string[] args)
        {
            Random rnd = new Random();
            int computerMove = rnd.Next(0, args.Length);
            return computerMove;

        }

        public static byte[] GenerateKey()
        {
            int size = 16;
            using (var generator = RandomNumberGenerator.Create())
            {
                var salt = new byte[size];
                generator.GetBytes(salt);
                return salt;
            }
        }

        static byte[] HMACHASH(string str, byte[] bkey)
        {
            using (var hmac = new HMACSHA256(bkey))
            {
                byte[] bstr = Encoding.Default.GetBytes(str);
                return hmac.ComputeHash(bstr);
            }
        }
    }
}
