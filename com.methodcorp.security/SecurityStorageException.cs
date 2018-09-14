using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.methodcorp.security
{
    class SecurityStorageException : Exception
    {
        public SecurityStorageException()
        {

        }

        public SecurityStorageException(string msg) : base(msg)
        {

        }

        public SecurityStorageException(string msg,Exception ex) : base(msg, ex)
        {

        }
    }
}
