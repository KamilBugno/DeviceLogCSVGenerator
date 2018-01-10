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
            fileWriter.SaveFirstRow();
            var dateList = GenerateSortedListOfDates();
            for (var numberOfRow = 0; numberOfRow < ConstantData.numberOfRows; numberOfRow++, ConstantData.key++)
            {
                var date = DateToString(dateList[numberOfRow]);
                var type = GenerateType();
                var source = GenerateSource(type);
                var information = GenerateBasicInformation(source);
                var complexInformation = GenerateComplexInformation(source);
                var status = complexInformation.status;
                var connection = complexInformation.connection;
                var TCP4 = complexInformation.TCP4;
                fileWriter.SaveRow(date, type, source, information, status, connection, TCP4);
            }
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
            return ChooseRandomlyFromBasicList(ConstantData.informationSourceOnType[type]);
        }

        public string GenerateBasicInformation(string source)
        {
            if(ConstantData.basicInformationOnInformationSource.Keys.Contains(source))
                return ChooseRandomlyFromBasicList(ConstantData.basicInformationOnInformationSource[source]);
            return string.Empty;
        }

        public (string status, string connection, string TCP4) GenerateComplexInformation(string source)
        {
            if (ConstantData.complexInformationOnInformationSource.Keys.Contains(source))
                return ChooseRandomlyFromComplexList(ConstantData.complexInformationOnInformationSource[source]);
            return (string.Empty, string.Empty, string.Empty);
        }

        private string ChooseRandomlyFromBasicList(string[] list)
        { 
            var maxValue = list.Length;
            var randomNumber = random.Next(0, maxValue);
            return list[randomNumber];
        }

        private (string, string, string) ChooseRandomlyFromComplexList(List<(string, string, string)> list)
        {
            var maxValue = list.Count;
            var randomNumber = random.Next(0, maxValue);
            return list[randomNumber];
        }


    }
}
