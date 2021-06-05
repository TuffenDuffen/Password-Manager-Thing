﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManger
{
    internal abstract class Encryptor
    {
        public static string EncryptCredential(Credential credential, int[] key)
        {
            string encrypted = EncryptString(credential.AppName, key).Length + "," +
                               EncryptString(credential.Email, key).Length + "," +
                               EncryptString(credential.Password, key).Length + " " +

                               EncryptString(credential.AppName, key) +
                               EncryptString(credential.Email, key) +
                               EncryptString(credential.Password, key);

            return encrypted;
        }

        private static string Caesarion(string encrypt, ulong shift)
        {
            char[] encryptArray = encrypt.ToCharArray();
            
            encryptArray = encryptArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar + shift)).ToArray();
            
            return encryptArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
        }

        public static string EncryptString(string encrypt, IEnumerable<int> key) //ToDo mek function us key
        {
            var randTest = new Random(encrypt.Length);
            foreach (int keyAtIndex in key)
            {
                switch (keyAtIndex)
                {
                    case 0:
                        encrypt = NextChar(encrypt);
                        break;
                    case 1:
                        encrypt = InvertBits(encrypt);
                        break;
                    case 2:
                        encrypt = LatinizeLol.ConvertStringToLatinNumber(encrypt);
                        break;
                    case 3:
                        encrypt = Caesarion(encrypt, (ulong) randTest.Next());
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                }
            }
            
            return encrypt;
        }
        //Gets next char and replaces old one

            //encryptions, replacecharwithnextchar, toandinvertbinary,

            private static string NextChar(string stringToNextChar) // adds one to the UTF-8 value
            {
                char[] stringToNextCharArray = stringToNextChar.ToCharArray();
            
                stringToNextCharArray = stringToNextCharArray.Select(Convert.ToUInt64).Select(utf8ValueFromChar => (char) (utf8ValueFromChar + 1)).ToArray();
            
                return stringToNextCharArray.Aggregate("", (current, cc) => current.Insert(0, cc.ToString()));
            }

            public static string InvertBits(string stringToInvert) // converts each characters UTF-8 value into bits and inverts it, then converts back to chars. China warning
            {
                char[] inverted = stringToInvert.ToCharArray();
                for (var i = 0; i < inverted.Length; i++)
                {
                    inverted[i] = (char) ~Convert.ToInt64(inverted[i]);
                }
            
                return new string(inverted);
            }
    }
}