using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BuildStudio.Core.Data.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Parent: Attribute
    {
        public Parent()
        {
            
        }
    }
}
