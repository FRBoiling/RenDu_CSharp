using Model.Base.Component;
using Model.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Component
{
    /// <summary>
    /// 消息分发组件
    /// </summary>
    public class MessageDispatcherComponent : AComponent
    {
        public readonly Dictionary<ushort, List<IMessageHandler>> Handlers = new Dictionary<ushort, List<IMessageHandler>>();
    }
}
