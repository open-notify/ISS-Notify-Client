using System;
using System.Collections.Generic;

namespace OpenNotify
{
    class ApiResponse
    {
        private string _message;
        private List<Pass> _passes;

        public ApiResponse()
        {
            _message = "failure";
            _passes = new List<Pass>();
        }

        public void ProccessData(dynamic obj)
        {
            try
            {
                _message = (string)obj.message;
                if (_message != "success") return;

                float apiLat = (float)obj.request.latitude;
                float apiLon = (float)obj.request.longitude;
                float apiAlt = (float)obj.request.altitude;

                int numpasses = (int)obj.request.passes;

                for (int i = 0; i < numpasses; i++)
                {
                    Int64 rt = (Int64)obj.response[i].risetime;
                    int d = (int)obj.response[i].duration;

                    Pass pass = new Pass(rt, d);
                    _passes.Add(pass);
                }
            }
            catch (Exception ex)
            {
                ///TODO: Deal with bad api return
                return;
            }
        }

        public List<Pass> Passes
        {
            get { return _passes; }
        }

        public string ResponseMessage
        {
            get { return _message; }
        }

        public override string ToString()
        {
            return _message;
        }
    }
}
