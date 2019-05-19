using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace ExtendedMethods
{
    public static class DateTimeExtensions
    {
        public static string ToXmlDateTime(this DateTime dateTime)
        {
            return dateTime.ToXmlDateTime(XmlDateTimeSerializationMode.Utc);
        }

        public static string ToXmlDateTime(this DateTime dateTime, XmlDateTimeSerializationMode mode = XmlDateTimeSerializationMode.Utc)
        {
            return XmlConvert.ToString(dateTime, mode);
        }

    }
}
