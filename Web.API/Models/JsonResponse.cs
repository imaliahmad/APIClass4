using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Models
{
    public class JsonResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public object Data { get; set; }
        public int ErrorCode { get; set; }
        public List<string> Errors { get; set; }
    }
}
