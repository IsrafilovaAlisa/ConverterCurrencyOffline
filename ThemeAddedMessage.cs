using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utf
{
    public class ThemeAddedMessage: ValueChangedMessage<string>
    {
        public ThemeAddedMessage(string value) : base(value)
        {
        }
    }
}
