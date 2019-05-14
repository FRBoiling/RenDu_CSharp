using Model.Base.Component;

namespace Model.Entity
{
    public sealed class SystemEntity : BaseEntity
    {
        public string Name { get; set; }

        public SystemEntity()
        {
        }

        public SystemEntity(long id) : base(id)
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
