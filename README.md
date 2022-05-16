# Abstracted-Weapon-Interface
PoC on how one can abstract implementation details of weapons/attacking using OOP design patterns in C# (Unity Engine)

This code uses a factory to abstract "low-level" details such as attacking with a weapon.
In this repo it's demonstrated with attack visuals.

## Usage:
Simply add your own logic to WeaponBase.cs, and attach Weapon.cs to your weapon prefab!

## How it works:
`WeaponBase.cs` defines some variables and methods for the weapon and exposes them to `WeaponFactory.cs`.

These implementation details are then exposed (via inheritance) to `Weapon.cs` as an `ActiveWeaponHandle`

Not only does this provide much cleaner code, it is also faster as it removes the need for any conditional statements to check which type of weapon code/logic is required:

The "Regular" way:
```cs
void Attack()
{
    // Note that this process must often be repeated for different functions thus violating the DRY principal.
    if (IsMelee)
    {
        // Melee weapon code
    }
    else
    {
        // Non-melee weapon code
    }
}
```

The factory way (i.e. this repository):
```cs
void Attack()
{
    /*
        Under the hood `ActiveWeaponHandle` is just a getter:
            protected OpaqueWeapon ActiveWeaponHandle { get => m_Factories[(byte)m_CurrentMapping].Handle; }
    */
    ActiveWeaponHandle.AttackVisuals(); // Particle effects, sounds, etc
    ActiveWeaponHandle.AttackLogic();   // Raycasts, hitbox detection, etc
}
```