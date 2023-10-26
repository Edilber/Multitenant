using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Application.DTOs
{
    public class ServiceResponse<T> where T : new()
    {
        public bool Success { get; set; }

        public List<ErrorDataModel> ErrorList { get; set; }

        public int TotalRecords { get; set; }

        public List<T> Data { get; set; }
    }
}
