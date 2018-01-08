using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class ResponseMetadata
    {
        private string _nextCursor;

        public string Next_Cursor
        {
            get { return _nextCursor; }
            set { _nextCursor = value; }
        }

        public ResponseMetadata()
        {

        }
    }
}
