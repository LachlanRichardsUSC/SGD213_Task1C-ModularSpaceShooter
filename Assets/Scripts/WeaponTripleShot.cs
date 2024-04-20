using UnityEngine;

/// <summary>
/// Implements a triple-shot firing mechanism. This weapon fires three bullets simultaneously
/// with each shot spaced horizontally.
/// </summary>
public class WeaponTripleShot : WeaponBase
{
    /// <summary>
    /// Multiplier used for the vertical component of the bullet's travel direction.
    /// </summary>
    [SerializeField]
    private int directionMultiplier = 1;

    /// <summary>
    /// Overrides the Shoot method to fire three bullets simultaneously. Bullets are fired only if 
    /// the elapsed time since the last shot is greater than the firing delay.
    /// </summary>
    public override void Shoot()
    {
        float currentTime = Time.time;
        Debug.Log("Attempting to shoot triple shot.");

        // Check if the fire delay has passed since the last shot
        if (currentTime - lastFiredTime > fireDelay)
        {
            // Calculate starting position for bullets to spread them horizontally
            float x = -0.5f;

            // Instantiate and position three bullets
            for (int i = 0; i < 3; i++)
            {
                GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
                if (newBullet.TryGetComponent(out EngineDirection engineDirection))
                {
                    // Adjust each bullet's horizontal position to spread them out
                    engineDirection.Direction = new Vector2(x + 0.5f * i, 0.5f * directionMultiplier);
                }
                else
                {
                    Debug.LogError("Newly instantiated bullet does not have an EngineDirection component.");
                }
            }

            // Update the time tracking variable
            lastFiredTime = currentTime;
        }
        else
        {
            Debug.Log("Fire delay not yet passed.");
        }
    }
}
