﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMM.Models.Lang
{
    public abstract class Operation : LangFeature
    {
        public abstract char Symbol { get; }
    }
}
