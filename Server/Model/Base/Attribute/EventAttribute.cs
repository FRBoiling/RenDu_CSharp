namespace Model.Base.RDAttribute
{
    public class EventAttribute : BaseAttribute
    {
        public string Type { get; }

        public EventAttribute(string type)
        {
            this.Type = type;
        }
    }
}
