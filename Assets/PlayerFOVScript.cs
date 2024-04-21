using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFOVScript : MonoBehaviour
{
    public Slider fovSlider; // Reference to the FOV slider
    public Camera playerCamera; // Reference to the player's camera

    private bool fovChanged = false; // Boolean to track if FOV has changed

    private void Start()
    {
        // Ensure the FOV slider's value matches the initial FOV of the camera
        fovSlider.value = playerCamera.fieldOfView;
        // Attach an event listener to the slider's OnValueChanged event
        fovSlider.onValueChanged.AddListener(ChangeFOV);
    }

    private void ChangeFOV(float newFOV)
    {
        // Update the player's camera FOV based on the slider value
        playerCamera.fieldOfView = newFOV;

        // Set the boolean to true to indicate that FOV has changed
        fovChanged = true;
    }

    // You can add a method to check the value of fovChanged if needed
    public bool HasFOVChanged()
    {
        return fovChanged;
    }
}
