using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IInteractable
{
    public DialogueNode dialogueNode;

    public void Interact()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueNode);
    }
}
