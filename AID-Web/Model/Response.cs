using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AID.Model
{
    public class ResponseModel
    {
        public bool success { get; set; }
        public Dictionary<string,object> data { get; set;}
        public string error { get; set;}

        public ResponseModel(bool success, Dictionary<string,object> data, string error) { 
            this.success = success;
            this.data = data;
            this.error = error;

        }
    }
}
