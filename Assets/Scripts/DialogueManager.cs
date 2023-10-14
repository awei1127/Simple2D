using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public GameObject DialogueBox;
    public float textSpeed;
    private Queue<Sentence> sentences;
    private List<Option> options;
    private Sentence sentence;
    public GameDirector gameDirector;
    private Action dialogueEndCallback;
    public DialogueOptionManager DialogueOptionManager;
    


    void Start()
    {
        sentences = new Queue<Sentence>();
    }

    public void StartDialogue(DialogueNode dialogueNode, Action onDialogueEnd = null)
    {
        gameDirector.SetGameState(GameState.Dialogue);

        DialogueBox.SetActive(true);

        sentences.Clear();

        // 把傳進來的sentence清單中的一個元素一個元素加到Queue裡面。
        foreach(Sentence sentence in dialogueNode.Sentences)
        {
            sentences.Enqueue(sentence);
        }

        options = dialogueNode.Options;

        dialogueEndCallback = onDialogueEnd;

        NextLine();
    }

    IEnumerator TypeLine(string sentence)
    {
        dialogueText.text = string.Empty;
        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    
    void NextLine()
    {
        // 如果已經到最後一行
        if (sentences.Count == 0)
        {
            // 如果有選項要秀給玩家選擇
            if (options.Count > 0)
            {
                DialogueOptionManager.ShowOptions(options);
                return;
            }

            EndDialogue();
            return;
        }
        sentence = sentences.Dequeue();
        nameText.text = sentence.Name ?? string.Empty;
        StartCoroutine(TypeLine(sentence.Text));
    }

    public void ContinueDialogue()
    {
        // 如果打字機還在跑
        if (dialogueText.text != sentence.Text)
        {
            StopAllCoroutines();
            dialogueText.text = sentence.Text;
            return;
        }
        NextLine();
    }

    void EndDialogue()
    {
        DialogueBox.SetActive(false);

        dialogueEndCallback?.Invoke();
        dialogueEndCallback = null;

        gameDirector.SetGameState(GameState.Exploring);
    }
}
