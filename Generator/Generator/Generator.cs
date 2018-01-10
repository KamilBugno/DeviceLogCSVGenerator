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
            var dateList = GenerateSortedListOfDates();
            for (var numberOfRow = 0; numberOfRow < ConstantData.numberOfRows; numberOfRow++, ConstantData.key++)
            {
                var date = DateToString(dateList[numberOfRow]);
                var type = GenerateType();
                var source = GenerateSource(type);
                var information = GenerateInformation(source);
                SaveRow(date, type, source, information);
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
            var firstRow = ConstantData.firstRow + Environment.NewLine;
            fileWriter.WriteToFile(firstRow);
        }

        public List<DateTime> GenerateSortedListOfDates()
        {
            List<DateTime> dateList = new List<DateTime>();
            for(var numberOfDates = 0; numberOfDates < ConstantData.numberOfRows; numberOfDates++)
            {
                dateList.Add(GenerateDate());
            }
            dateList.Sort();
            return dateList;
        }

        public DateTime GenerateDate()
        {
            //np. 2017-12-28T14:43:04.201
            var year = ConstantData.year;
            var month = ConstantData.month;
            var day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            var hour = random.Next(0, 24);
            var minute = random.Next(0, 60);
            var second = random.Next(0, 60);
            var date = new DateTime(year, month, day, hour, minute, second);
            return date;
            
        }

        public string DateToString(DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ss.000");
        }

        public string GenerateType()
        {
            var typeId = random.Next(0, ConstantData.type.Length);
            return ConstantData.type[typeId];
        }

        public string GenerateSource(string type)
        {
            return ChooseRandomlyFromList(ConstantData.informationSourceOnType[type]);
        }

        public string GenerateInformation(string source)
        {
            return ChooseRandomlyFromList(ConstantData.informationOnInformationSource[source]);
        }

        private string ChooseRandomlyFromList(string[] list)
        { 
            var maxValue = list.Length;
            var randomNumber = random.Next(0, maxValue);
            return list[randomNumber];
        }


    }
}
