using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Message
{
    public interface IMessageHandler
    {
        void Handle(Session session, object message);
        Type GetMessageType();
    }
}
