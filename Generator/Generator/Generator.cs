using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Generator
    {
        FileWriter fileWriter;
        Random random;

        public Generator()
        {
            fileWriter = new FileWriter();
            random = new Random();
        }

        public void Generate()
        {
            SaveFirstRow();
            for (var numberOfRow = 0; numberOfRow < ConstantData.numberOfRows; numberOfRow++, ConstantData.key++)
            {
                var type = GenerateType();
                var source = GenerateSource(type);
                SaveRow(GenerateDate(), type, source, GenerateInformation(source));
            }
        }

        public void SaveRow(string date, string type, string source, string information)
        {
            var row = $"{ConstantData.key},{ConstantData.deviceSN},";
            row += $"{date},{type},{source},{information}";
            row += Environment.NewLine;
            fileWriter.WriteToFile(row);
        }

        public void SaveFirstRow()
        {
            var firstRow = "_key,device_SN,date,type,source,information" + Environment.NewLine;
            fileWriter.WriteToFile(firstRow);
        }

        public string GenerateDate()
        {
            //np. 2017-12-28T14:43:04.201
            var now = DateTime.Now;
            var day = random.Next(1, 29);
            var hour = random.Next(0, 25);
            var minute = random.Next(0, 60);
            var second = random.Next(0, 60);
            var thousandth = random.Next(0, 1000);
            var date = new DateTime(now.Year, now.Month, day, hour, minute, second);
            return date.ToString("yyyy-MM-ddTHH:mm:ss.") + thousandth;
        }

        public string GenerateType()
        {
            var typeId = random.Next(0, ConstantData.type.Length);
            return ConstantData.type[typeId];
        }

        public string GenerateSource(string type)
        {
            if(type == "debug")
            {
                return ConstantData.informationSource[0];
            } else
            {
                return ConstantData.informationSource[1];
            }
        }

        public string GenerateInformation(string source)
        {
            if (source == "OS")
            {
                return ChooseRandomlyFromList(ConstantData.informationFromOS);
            }
            else if (source == "Battery Monitor")
            {
                return ChooseRandomlyFromList(ConstantData.informationFromBatteryMonitor);
            }
            return String.Empty;
        }

        private string ChooseRandomlyFromList(string[] list)
        { 
            var maxValue = list.Length;
            var randomNumber = random.Next(0, maxValue);
            return list[randomNumber];
        }


    }
}
