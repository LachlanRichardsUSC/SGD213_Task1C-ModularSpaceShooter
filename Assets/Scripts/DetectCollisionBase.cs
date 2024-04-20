using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for detecting collisions based on tag lists and handling them accordingly.
/// Allows for specifying behaviors as either a blacklist or a whitelist.
/// </summary>
public class DetectCollisionBase : MonoBehaviour
{
    [SerializeField]
    private TagListType tagListType = TagListType.Blacklist;  

    [SerializeField]
    private List<string> tags;

    /// <summary>
    /// Checks for entering triggers and processes collisions based on tag list type.
    /// </summary>
    /// <param name="other">The Collider2D of the other GameObject.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        ProcessBasedOnTag(other.gameObject);
    }

    /// <summary>
    /// Checks for physical collisions and processes collisions based on tag list type.
    /// </summary>
    /// <param name="other">The Collision2D of the other GameObject.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        ProcessBasedOnTag(other.gameObject);
    }

    /// <summary>
    /// Determines whether to process a collision based on the current tag list type and the object's tag.
    /// </summary>
    /// <param name="other">The GameObject that collided.</param>
    private void ProcessBasedOnTag(GameObject other)
    {
        bool tagInList = tags.Contains(other.tag);
        if ((tagListType == TagListType.Blacklist && tagInList) ||
            (tagListType == TagListType.Whitelist && !tagInList))
        {
            ProcessCollision(other);
        }
    }

    /// <summary>
    /// Processes the collision with another GameObject.
    /// This method is virtual and can be overridden in derived classes to implement specific collision behaviors.
    /// </summary>
    /// <param name="other">The GameObject involved in the collision.</param>
    protected virtual void ProcessCollision(GameObject other)
    {
        Debug.Log("Detected collision with " + other.name);
    }
}

/// <summary>
/// Enum to define how the tags list should be interpreted: as a blacklist or a whitelist.
/// </summary>
public enum TagListType
{
    Blacklist,
    Whitelist
}
