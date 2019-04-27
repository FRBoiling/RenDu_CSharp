using Model.Base.Component;

namespace Model.Entity
{
    public sealed class Context : BaseEntity
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
