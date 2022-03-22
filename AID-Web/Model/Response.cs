using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Model
{
    public class ResponseModel<T>
    {
        public bool success { get; set; }
        public T data { get; set;}
        public string error { get; set;}

        public ResponseModel(bool success, T data , string error) { 
            this.success = success;
            this.data = data;
            this.error = error;

        }
    }
}
