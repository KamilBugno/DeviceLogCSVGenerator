﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            generator.Generate();
        }
    }
}
