using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    public BoxCollider2D doorCollider;
    private Animator animator;

    public void Interact()
    {
        ToggleSwitch();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSwitch()
    {
        Debug.Log("觸發門開關");
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
        doorCollider.enabled = !doorCollider.enabled;
    }
}
