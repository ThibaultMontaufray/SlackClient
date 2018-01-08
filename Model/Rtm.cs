using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class Rtm : Permission
    {
        #region Attributes
        private string _url;
        private Team _team;
        private Self _self;
        private Users _users;
        private ChannelList _channels;
        private GroupList _groups;
        private List<Mpim> _mpims;
        private ImList _ims;
        #endregion

        #region Properties
        public Self Self
        {
            get { return _self; }
            set { _self = value; }
        }
        public Team Team
        {
            get { return _team; }
            set { _team = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public ImList Ims
        {
            get { return _ims; }
            set { _ims = value; }
        }
        public List<Mpim> Mpims
        {
            get { return _mpims; }
            set { _mpims = value; }
        }
        public GroupList Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }
        public ChannelList Channels
        {
            get { return _channels; }
            set { _channels = value; }
        }
        public Users Users
        {
            get { return _users; }
            set { _users = value; }
        }
        #endregion

        #region Constructor
        public Rtm()
        {
            _mpims = new List<Mpim>();
        }
        #endregion
    }
}
