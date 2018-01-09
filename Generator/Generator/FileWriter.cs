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
        public void WriteToFile(string text)
        {
            File.AppendAllText(ConstantData.fileName, text);
        }
    }
}
