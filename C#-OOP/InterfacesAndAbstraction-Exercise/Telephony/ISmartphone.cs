using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartphone
    {
        void Calling(string number);

        void Browsing(string URl);
    }
}
