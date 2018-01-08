using Newtonsoft.Json;

namespace SlackClient
{
    public class Latest
    {
        private string _latest;

        public string Text
        {
            get { return _latest; }
            set { _latest = value; }
        }

        public Latest()
        {

        }
    }
}