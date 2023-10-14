using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestionDialogueUI : MonoBehaviour
{
    public TextMeshProUGUI Question;
    public Button yesBtn;
    public Button noBtn;

    public void ShowQuestion(string question, Action yesAction, Action noAction)
    {
        gameObject.SetActive(true);

        Question.text = question;

        yesBtn.onClick.AddListener(() =>
        {
            Hide();
            yesAction();
        });
        noBtn.onClick.AddListener(() =>
        {
            Hide();
            noAction();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
