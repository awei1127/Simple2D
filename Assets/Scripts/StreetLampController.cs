using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StreetLampController : MonoBehaviour, IInteractable
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        ToggleSwitch();
    }

    public void ToggleSwitch()
    {
        Debug.Log("觸發路燈開關");
        animator.SetBool("isLightOn", !animator.GetBool("isLightOn"));
    }
}
