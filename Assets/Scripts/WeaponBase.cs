using UnityEngine;

/// <summary>
/// Abstract base class for all weapon types. Handles common weapon functionalities
/// and provides a framework for specific weapon behaviors.
/// </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField]
    // The delay between consecutive fires of the weapon
    protected float fireDelay = 1f; 

    [SerializeField]
    // The bullet prefab that this weapon fires
    protected GameObject bullet; 

    /// <summary>
    /// Gets or sets the bullet prefab used by this weapon.
    /// </summary>
    public GameObject Bullet
    {
        get { return bullet; }
        set { bullet = value; }
    }

    [Header("References")]
    [SerializeField]
    // The point from which bullets are spawned
    protected Transform bulletSpawnPoint; 

    /// <summary>
    /// Gets or sets the transform at which bullets will spawn.
    /// </summary>
    public Transform BulletSpawnPoint
    {
        get { return bulletSpawnPoint; }
        set { bulletSpawnPoint = value; }
    }

    // The time at which the weapon last fired
    protected float lastFiredTime = 0f;

    /// <summary>
    /// Abstract method to handle the shooting mechanism. Each derived class must implement its own shooting behavior.
    /// Should account for the fire delay to control shooting frequency.
    /// </summary>
    public abstract void Shoot();

    /// <summary>
    /// Updates the weapon controls (like bullet spawn point and bullet prefab) using another weapon's settings.
    /// Useful for swapping weapons and retaining control settings.
    /// </summary>
    /// <param name="oldWeapon">The weapon whose settings are to be copied.</param>
    public virtual void UpdateWeaponControls(WeaponBase oldWeapon)
    {
        bulletSpawnPoint = oldWeapon.BulletSpawnPoint;
        bullet = oldWeapon.Bullet;
    }
}
