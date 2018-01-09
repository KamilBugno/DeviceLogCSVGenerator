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
                SaveRow(GenerateDate(), type, GenerateSource(), GenerateInformation(type));
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

        public string GenerateSource()
        {
            return "source";
        }

        public string GenerateInformation(string type)
        {
            return "information";
        }


    }
}
