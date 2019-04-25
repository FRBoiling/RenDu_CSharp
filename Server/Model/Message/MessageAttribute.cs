using Model.RDAttribute;

namespace Model.Message
{
    public class MessageAttribute : BaseAttribute
    {
        public ushort Opcode { get; }

        public MessageAttribute(ushort opcode)
        {
            this.Opcode = opcode;
        }
    }
}
