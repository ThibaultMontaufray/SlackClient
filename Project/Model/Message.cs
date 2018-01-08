using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class Message
    {
        private string _type;
        private double _ts;
        private string _user;
        private string _text;
        private bool _isStarred;
        private List<Reaction> _reactions;
        private List<Attachment> _attachments;
        private string _userName;
        private string _botId;
        private string _subType;

        public List<Attachment> Attachements
        {
            get { return _attachments; }
            set { _attachments = value; }
        }
        public string SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }
        public string Bot_Id
        {
            get { return _botId; }
            set { _botId = value; }
        }
        public string User_Name
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public List<Reaction> Reactions
        {
            get { return _reactions; }
            set { _reactions = value; }
        }

        public bool IsStarred
        {
            get { return _isStarred; }
            set { _isStarred = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public double Ts
        {
            get { return _ts; }
            set { _ts = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Message()
        {
            _reactions = new List<Reaction>();
        }
    }
}
