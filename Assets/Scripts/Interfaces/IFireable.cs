using System.Numerics;

namespace Shooter2D.Interfaces
{
    public interface IFireable
    {
       
        void Fire(Vector2 direction);
        void Reload();
        bool CanFire { get; }
    }
}
