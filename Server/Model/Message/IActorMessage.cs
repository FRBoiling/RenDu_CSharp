using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Message
{
    // 不需要返回消息
    public interface IActorMessage : IMessage
    {
        long ActorId { get; set; }
    }

    public interface IActorRequest : IRequest
    {
        long ActorId { get; set; }
    }

    public interface IActorResponse : IResponse
    {
    }
}
