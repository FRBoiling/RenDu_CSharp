using Model.Component;

namespace Model
{
    public sealed class Context : Entity
    {
        public string Name { get; set; }

        public Context()
        {
        }

        public Context(long id) : base(id)
        {
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();
        }
    }
}
