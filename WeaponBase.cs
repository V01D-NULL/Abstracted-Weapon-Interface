using UnityEngine;
using Mirror;

public class WeaponBase : MonoBehaviour
{
    protected FactoryMapping m_CurrentMapping;
    protected WeaponFactory[] m_Factories = new WeaponFactory[2];

    // Return a handle from the currently active factory (i.e. the current weapon)
    protected OpaqueWeapon ActiveWeaponHandle { get => m_Factories[(byte)m_CurrentMapping].Handle; }

    protected void Init()
    {
        // Switching a weapon would be as simple as changing m_CurrentMapping
        m_Factories[0] = new RangedWeapon(this);
        m_Factories[1] = new MeleeWeapon(this);

        // Here you'd have some logic to specify which weapon to select.
        m_CurrentMapping = FactoryMapping.FACTORY_RANGED;
    }

    public BulletScript CreateBullet(Transform transform)
    {
        // Take a bullet from the object pool and instantiate it at 'transform.position/rotation'
        return null;
    }

    public void CreateHitParticleEffect(Vector3 pos)
    {
        // Play a particle effect at 'pos' (world coords) when the bullet hit's something
    }


    protected enum FactoryMapping : byte
    {
        FACTORY_RANGED = 0,
        FACTORY_MELEE = 1
    }
}
