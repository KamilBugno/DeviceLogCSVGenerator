using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class FileWriter
    {
        public void SaveFirstRow()
        {
            var firstRow = ConstantData.firstRow + Environment.NewLine;
            WriteToFile(firstRow);
        }

        public void SaveRow(string date, string type, string source, string information,
           string status, string connection, string TCP4)
        {
            var row = $"{ConstantData.key},{ConstantData.deviceSN},";
            row += $"{date},{type},{source},{information},";
            row += $"{status},{connection},{TCP4}";
            row += Environment.NewLine;
            WriteToFile(row);

        }

        public void WriteToFile(string text)
        {
            File.AppendAllText(ConstantData.fileName, text);
        }

    }
}
