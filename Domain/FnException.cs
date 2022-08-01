using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyImages.Domain
{
    public abstract class FnException : Exception
    {
        public string Code { get; }

        protected FnException()
        {
        }

        public FnException(string code)
        {
            Code = code;
        }

        public FnException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public FnException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public FnException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public FnException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
