using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2139_Lab9.Models
{
    public class Cell
    {
        public string Id{ set; get; }

        public string Mark { get; set; }

        public bool IsBlank => string.IsNullOrEmpty(Mark);

        public bool IsEndCell => Id.EndsWith("Right");
    }
 }
