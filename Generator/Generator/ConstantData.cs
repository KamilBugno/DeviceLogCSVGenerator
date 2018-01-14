using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class ConstantData
    {
        public static string fileName = "./100-logs-csv.csv";
        public static int numberOfRows = 100;
        public static int year = 2018;
        public static int month = 1;
        public static int key = 1;
        public static string deviceSN = "APMK920923744240509";
        public static string TCP4 = "181.24.201.12:442";
        public static string firstRow = "_key,device_SN,date,type,source,information,status,connection,TCP4";
        public static string[] type = { "debug", "information" };
        public static string[] informationSourceForDebug = { "OS", "Battery Monitor", "Avast"};
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
        public static List<(string, string, string)> informationFromAvast = new List<(string status, string connection, string TCP4)>
        {
            (status: "successful update", connection: "established", TCP4: TCP4),
            (status: "in use", connection: "established", TCP4: TCP4)
        };
        public static Dictionary<string, string[]> basicInformationOnInformationSource = new Dictionary<string, string[]>()
        {
            {"OS", informationFromOS},
            {"Battery Monitor", informationFromBatteryMonitor},
            {"Phone Call Manager", informationFromPhoneCallManager}
        };
        public static Dictionary<string, List<(string, string, string)>> complexInformationOnInformationSource = new Dictionary<string, List<(string, string, string)>>()
        {
            {"Avast", informationFromAvast}
        };

    }
}
