namespace Shooter2D.Interfaces
{
    public interface IFireable
    {
        void Fire();
        void Reload();
        bool CanFire { get; }
    }
}
