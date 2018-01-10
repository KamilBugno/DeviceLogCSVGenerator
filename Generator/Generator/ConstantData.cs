using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class ConstantData
    {
        public static string fileName = "./plik654321.txt";
        public static int numberOfRows = 10;
        public static int year = 2018;
        public static int month = 1;
        public static int key = 1;
        public static string deviceSN = "APMK920923744240509";
        public static string firstRow = "_key,device_SN,date,type,source,information";
        public static string[] type = { "debug", "information" };
        public static string[] informationSourceForDebug = { "OS", "Battery Monitor" };
        public static string[] informationSourceForInformation = { "Phone Call Manager" };
        public static Dictionary<string, string[]> informationSourceOnType = new Dictionary<string, string[]>()
            {
                {"debug", informationSourceForDebug},
                {"information", informationSourceForInformation}
            };
        public static string[] informationFromOS = { "successful unlock", "unsuccessful unlock",
           "successful lock", "turn off", "turn on", "wrong PIN", "correct PIN"};
        public static string[] informationFromBatteryMonitor = { "low battery", "battery charging",
            "high level of battery", "discharging"};
        public static string[] informationFromPhoneCallManager = { "making a call", "receiving a call",
            "sending text", "receiving text"};
        public static Dictionary<string, string[]> informationOnInformationSource = new Dictionary<string, string[]>()
            {
                {"OS", informationFromOS},
                {"Battery Monitor", informationFromBatteryMonitor},
                {"Phone Call Manager", informationFromPhoneCallManager}
            };

    }
}
