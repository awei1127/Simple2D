using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;
    float InteractRange = 1;
    Rigidbody2D rb;
    Vector2 moveDirection;
    Animator animator;
    public GameDirector gameDirector;
    public DialogueManager dialogueManager;
    
    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (gameDirector.currentState)
        {
            case GameState.Exploring:

                float moveX = Input.GetAxisRaw("Horizontal");
                float moveY = Input.GetAxisRaw("Vertical");
                moveDirection = new Vector2(moveX, moveY).normalized;

                // 移動動畫
                animator.SetFloat("Horizontal", moveX);
                animator.SetFloat("Vertical", moveY);
                animator.SetFloat("Speed", moveDirection.sqrMagnitude);

                // 閒置面向
                if (moveDirection.sqrMagnitude != 0)
                {
                    animator.SetFloat("FaceHorizontal", moveX);
                    animator.SetFloat("FaceVertical", moveY);
                }

                // 跟物件互動
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // 取得面向
                    Vector2 dir = new Vector2(animator.GetFloat("FaceHorizontal"), animator.GetFloat("FaceVertical"));
                    // 取得layer
                    LayerMask layerMask = LayerMask.GetMask("Interactable");
                    // 發射射線
                    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, dir, InteractRange, layerMask);
                    // 如果有碰到碰撞器，嘗試取得interface組件，若取得，執行interface的互動方法
                    if (hitInfo.collider != null)
                    {
                        if (hitInfo.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable interactObj))
                        {
                            // 停止移動，停止移動動畫
                            moveDirection = Vector2.zero;
                            animator.SetFloat("Speed", 0f);
                            // 互動
                            interactObj.Interact();
                        }
                    }
                }
                break;

            case GameState.Dialogue:
                // 如果玩家按空白鍵
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dialogueManager.ContinueDialogue();
                }
                break;

            default:
                break;
        }
    }
    void FixedUpdate()
    {
        // 移動
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}
