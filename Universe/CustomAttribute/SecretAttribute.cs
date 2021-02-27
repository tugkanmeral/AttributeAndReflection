using System;
using System.Collections.Generic;
using System.Text;

namespace Universe.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SecretAttribute : Attribute
    {
    }
}
