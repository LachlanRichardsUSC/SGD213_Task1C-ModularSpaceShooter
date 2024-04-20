using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private Slider sldPlayerHealth;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("There is more than one UIManager in the scene. Destroying duplicate.");
            Destroy(this.gameObject);  // Optionally destroy this gameObject to prevent duplicate
            return;
        }
        instance = this;
        
    }

    public void UpdatePlayerHealthSlider(float percentage)
    {
        if (sldPlayerHealth != null)
        {
            sldPlayerHealth.value = percentage;
        }
        else
        {
            Debug.LogError("Slider sldPlayerHealth is not assigned in the inspector.");
        }
    }
}
