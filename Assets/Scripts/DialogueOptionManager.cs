using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionManager : MonoBehaviour
{
    public GameObject optionPanelPrefab;
    public Transform optionContainer;

    public void ShowOptions(List<Option> options)
    {
        // 清除舊的選項按鈕
        foreach (Transform child in optionContainer)
        {
            Destroy(child.gameObject);
        }

        // 為每個選項創建一個新的按鈕
        foreach (Option option in options)
        {
            // 用模板創建一個物件交給optionPanel變量來引用，並將他設為optionContainer的子物件。
            GameObject optionPanel = Instantiate(optionPanelPrefab, optionContainer);
            TextMeshProUGUI panelText = optionPanel.GetComponentInChildren<TextMeshProUGUI>();
            panelText.text = option.Text;

            // 設置按鈕寬度以適應文字 (取得文字的首選寬度，然後把這個寬度給按鈕的寬度)
            float preferredWidth = panelText.preferredWidth + 20;  // 添加一些緩衝
            optionPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(preferredWidth, optionPanel.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}
