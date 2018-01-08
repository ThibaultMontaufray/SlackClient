using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class GroupList
    {
        private List<Group> _groups;
        private bool _ok;

        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }
        public List<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        public GroupList()
        {
            _groups = new List<Group>();
        }
    }
}
