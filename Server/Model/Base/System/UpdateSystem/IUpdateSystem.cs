using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Base.System
{
    public interface IUpdateSystem
    {
        Type Type();
        void Run(object o);
    }
}
