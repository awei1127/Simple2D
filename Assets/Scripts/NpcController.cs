using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour, IInteractable
{
    Animator animator;
    public DialogueNode[] dialogueNodes;
    public Vector2 originalDirection;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        FacePlayer();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueNodes[0], ResetDirection);
    }

    void FacePlayer()
    {
        // 取得玩家位置，與自己位置相減來獲得方向
        Vector2 playerPos = FindObjectOfType<PlayerController>().transform.position;
        Vector2 dir = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y);
        // 把方向帶入animator
        animator.SetFloat("FaceHorizontal", dir.x);
        animator.SetFloat("FaceVertical", dir.y);
    }

    void ResetDirection()
    {
        // 把方向帶入animator
        animator.SetFloat("FaceHorizontal", originalDirection.x);
        animator.SetFloat("FaceVertical", originalDirection.y);
    }
}
