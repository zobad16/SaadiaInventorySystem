using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.Util
{
    public class BaseResponse<T>
    {
        private string _errorCode;
        public string ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }


        private T _data;
        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }


    }
}
