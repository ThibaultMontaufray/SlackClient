using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class ImList
    {
        private List<Im> _ims;
        private bool _ok;

        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }
        public List<Im> Ims
        {
            get { return _ims; }
            set { _ims = value; }
        }

        public ImList()
        {
            _ims = new List<Im>();
        }
    }
}
