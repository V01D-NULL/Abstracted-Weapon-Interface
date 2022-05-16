using UnityEngine;
using Mirror;

public struct WeaponHitInfo
{
    public Vector3 impactPoint;

    public Vector3 bulletDir;

    public float damage;
}

// This script would be attached to a weapon prefab
public class Weapon : WeaponBase
{
    private void Start()
    {
        base.Init();
    }

    public void PlayFireVisuals(WeaponHitInfo hitInfo)
    {
        // It's as simple as that :^)
        ActiveWeaponHandle.AttackVisuals(hitInfo);
    }
}