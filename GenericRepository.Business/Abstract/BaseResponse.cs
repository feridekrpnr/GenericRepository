using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GenericRepository.Business.Abstract
{
    public abstract class BaseResponse
    {
        public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;
        public string Message { get; set; } = null;
        public string FriendlyMessage { get; set; }
        public List<string> Errors { get; set; } = null;
        public int ErrorCode { get; set; } = 0;
        public int? TotalCount { get; set; } = null;
        public int? RecordsTotal { get; set; } = null;
        public int? RecordsFiltered { get; set; } = null;
    }

}
