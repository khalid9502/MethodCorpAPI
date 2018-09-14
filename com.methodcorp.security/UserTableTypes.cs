using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.methodcorp.security
{
    class strings : List<string>
    {
       public strings() { }

    }

    public class objectSecurity
    {
        string name;
        bool allowRead;
        bool allowUpdate;
        bool allowDelete;
        //csum
        public objectSecurity()
        {

        }

        public objectSecurity(string Name,bool AllowRead, bool AllowUpdate, bool AllowDelete)
        {
            this.name = Name;
            this.allowRead = AllowRead;
            this.allowUpdate = AllowUpdate;
            this.allowDelete = AllowDelete;
        }
    }

    public class policySecurity
    {
        string name;
        bool allow;
        string data;
        //csum
        public policySecurity()
        {

        }

        public policySecurity(string Name,bool Allow,string Data)
        {
            this.name = Name;
            this.allow = Allow;
            this.data = Data;
        }
    }
}
