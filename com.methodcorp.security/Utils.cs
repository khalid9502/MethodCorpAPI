using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace com.methodcorp.security
{
    static class Utils
    {
        public static Object GetPropertyValue(this Object Obj, string Name)
        {
            foreach (string part in Name.Split('.'))
            {
                if (Obj == null)
                {
                    return null;
                }
                Type type = Obj.GetType();
                PropertyInfo propertyinfo = type.GetProperty(part);
                if (propertyinfo == null)
                {
                    return null;
                }
                Obj = propertyinfo.GetValue(Obj, null);
            }
            return Obj;
        }
    }
}
