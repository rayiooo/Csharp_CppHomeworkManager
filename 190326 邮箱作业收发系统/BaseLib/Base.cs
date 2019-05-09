﻿using System;
using System.Net.NetworkInformation;
using System.Text;

namespace EmailHomeworkSystem.BaseLib {
    class Base {
        /// <summary>
        /// 提取字符串中的中文
        /// </summary>
        public static string GetChinese(string str) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str.ToCharArray()) {
                if (c >= 0x4e00 && c <= 0x9fa5) {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string GetCurrentTime() {
            return DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetMac() {
            try {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces) {
                    string mac = BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                    Log.D("Base.GetMac.mac: " + mac);
                    return mac;
                }
            } catch (Exception) {
                Log.E("Mac address not found.");
            }
            return "00-00-00-00-00-00";
        }

        public static string GetTimeStamp() {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;
            return timeStamp.ToString();
        }

        public static string MD5(string str) {
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
