﻿using Models.Attributes;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tools
{
    [ToolName("Shoot Yourself Tool")]
    public class ShootYourselfInTheFaceTool : ITool
    {
        public string Name => this.GetType().Name;

        public void Disable()
        {
            Console.WriteLine($"Disabled {Name.ToString()}");
        }

        public void Enable()
        {
            Console.WriteLine($"Enabled {Name.ToString()}");
        }
    }
}
