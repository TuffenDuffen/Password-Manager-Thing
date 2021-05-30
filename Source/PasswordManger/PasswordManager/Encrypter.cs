﻿using System;
using System.Collections;
using System.Linq;

namespace PasswordManger
{
    internal static class Encryptor
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

        public static string EncryptString(string encrypt, int[] key) //ToDo mek function us key
        {
            string encrypted = NextChar(encrypt);
            encrypted = InvertBits(encrypted);
            return encrypted;
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