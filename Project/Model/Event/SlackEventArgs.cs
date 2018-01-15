﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackClient
{
    public class SlackEventArgs
    {
        public Event Data { get; private set; }

        public SlackEventArgs(Event e)
        {
            this.Data = e;
        }
    }
}
