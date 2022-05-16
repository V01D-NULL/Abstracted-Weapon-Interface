/*
 * Factory implementation for guns and swords 
 *
*/

// Product
public abstract class OpaqueWeapon
{
	public WeaponBase m_weaponBase;
	public abstract void AttackVisuals(WeaponHitInfo hitInfo);
}

// Concrete product
public class OpaqueRangedWeapon : OpaqueWeapon
{
	public override void AttackVisuals(WeaponHitInfo hitInfo)
	{
        // Do things like move the bullet, play a shooting sound, play a particle system for the muzzle flash, etc.

		var bullet = m_weaponBase.CreateBullet(m_weaponBase.FirePoint);

		bullet.Init();
		bullet.m_Forward = (hitInfo.impactPoint - m_weaponBase.FirePoint.position).normalized;
		bullet.m_Speed = 10;

        // Tell the bullet to move in this direction
		bullet.SetTarget(hitInfo.impactPoint);

		m_weaponBase.CreateHitParticleEffect(hitInfo.impactPoint);
	}
}

// Concrete product
public class OpaqueMeleeWeapon : OpaqueWeapon
{
	public override void AttackVisuals(WeaponHitInfo hitInfo) { }
}

// Creator
public abstract class WeaponFactory
{
	public OpaqueWeapon Handle;
	public WeaponFactory() => this.FactoryMethod();
	public abstract void FactoryMethod();
}

// Concrete creator
public class RangedWeapon : WeaponFactory
{
	public RangedWeapon(WeaponBase weaponBase) => base.Handle.m_weaponBase = weaponBase;

	public override void FactoryMethod()
	{
		base.Handle = new OpaqueRangedWeapon();
	}
}

// Concrete creator
public class MeleeWeapon : WeaponFactory
{
	public MeleeWeapon(WeaponBase weaponBase) => base.Handle.m_weaponBase = weaponBase;

	public override void FactoryMethod()
	{
		base.Handle = new OpaqueMeleeWeapon();
	}
}
