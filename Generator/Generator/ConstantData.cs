using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class ConstantData
    {
        public static String fileName = "./plik654321.txt";
        public static int numberOfRows = 10;
        public static int key = 1;
        public static String deviceSN = "APMK920923744240509";
        public static String[] type = { "debug", "information" };
        public static String[] informationSource = { "OS", "Battery Monitor" };
        public static String[] informationFromOS = { "successful unlock", "unsuccessful unlock",
           "successful lock", "turn off", "turn on", "wrong PIN", "correct PIN"};
        public static String[] informationFromBatteryMonitor = { "low battery", "battery charging",
            "high level of battery", "discharging"};

    }
}
