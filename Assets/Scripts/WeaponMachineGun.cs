using UnityEngine;

/// <summary>
/// Implements a machine gun firing mechanism. This weapon fires bullets continuously at a
/// fixed rate defined by the fireDelay.
/// </summary>
public class WeaponMachineGun : WeaponBase
{
    /// <summary>
    /// Overrides the Shoot method to continuously fire bullets at a rate determined by fireDelay.
    /// Each bullet is instantiated only if enough time has passed since the last shot.
    /// </summary>
    public override void Shoot()
    {
        float currentTime = Time.time;

        // Check if the cooldown period (fireDelay) has passed to allow shooting a new bullet.
        if (currentTime - lastFiredTime > fireDelay)
        {
            // Instantiate the bullet at the specified spawn point with the weapon's current orientation.
            GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);

            // Update the last fired time to the current time after shooting.
            lastFiredTime = currentTime;

            // Optionally log shooting action for debugging purposes (comment out if not needed).
            Debug.Log("Machine gun shot fired at: " + Time.time);
        }
    }
}
