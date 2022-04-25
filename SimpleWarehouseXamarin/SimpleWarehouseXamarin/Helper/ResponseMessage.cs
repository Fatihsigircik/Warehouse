using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleWarehouseMobil.Helpers
{
    class ResponseMessage<T>
	{
        public string Status { get; set; }

        public string Model { get; set; }

        public string Message { get; set; }

        public string SpecialMessage { get; set; }

        public List<T> Data { get; set; }
        
    }
}