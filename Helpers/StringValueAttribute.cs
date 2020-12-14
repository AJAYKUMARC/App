using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Helpers
{
    public sealed class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Holds the string value for a value in an enum.
        /// </summary>
        public string StringValue { get; private set; }

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            StringValue = value;
        }
    }
}
