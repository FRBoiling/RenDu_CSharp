﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.System
{
    public interface IDestroySystem
    {
        Type Type();
        void Run(object o);
    }

}
