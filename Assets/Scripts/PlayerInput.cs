using UnityEngine;

/// <summary>
/// Handles all player-specific input behavior, passing the input information
/// to the appropriate scripts to control movement and weapon firing.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    // Reference to the EngineBase component for movement controls.
    private EngineBase engineBase;

    // Reference to the currently equipped WeaponBase component.
    private WeaponBase weapon;

    /// <summary>
    /// Gets or sets the WeaponBase component representing the player's current weapon.
    /// </summary>
    public WeaponBase Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }

    void Start()
    {
        // Populate references to required components.
        engineBase = GetComponent<EngineBase>();
        weapon = GetComponent<WeaponBase>();
    }

    void Update()
    {
        HandleMovementInput();
        HandleShootingInput();
    }

    /// <summary>
    /// Reads horizontal movement input and commands the player to move accordingly.
    /// </summary>
    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0.0f && engineBase != null)
        {
            engineBase.Accelerate(horizontalInput * Vector2.right);
        }
    }

    /// <summary>
    /// Checks if the Fire1 button is pressed and commands the weapon to shoot.
    /// </summary>
    private void HandleShootingInput()
    {
        if (Input.GetButton("Fire1") && weapon != null)
        {
            weapon.Shoot();
        }
    }

    /// <summary>
    /// Swaps the current weapon to a new weapon type, removing the old weapon component and adding a new one.
    /// </summary>
    /// <param name="weaponType">The type of weapon to swap to, defined by the WeaponType enum.</param>
    public void SwapWeapon(WeaponType weaponType)
    {
        WeaponBase newWeapon = null;
        switch (weaponType)
        {
            case WeaponType.MachineGun:
                newWeapon = gameObject.AddComponent<WeaponMachineGun>();
                break;
            case WeaponType.TripleShot:
                newWeapon = gameObject.AddComponent<WeaponTripleShot>();
                break;
        }

        if (newWeapon != null)
        {
            newWeapon.UpdateWeaponControls(weapon);
            Destroy(weapon);
            weapon = newWeapon;
        }
    }
}
