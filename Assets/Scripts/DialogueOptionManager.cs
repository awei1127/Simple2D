using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionManager : MonoBehaviour
{
    public GameObject optionObjPrefab;
    public Transform optionContainer;
    private int selectedOptionIndex = 0;  // 當前選擇的選項索引
    public List<Button> optionsButtons = new List<Button>();  // 存儲按鈕引用的列表
    public Color normalColor;
    public Color hightlightColor;
    private float maxButtonWidth;
    public GameDirector gameDirector;

    void Update()
    {
        if (gameDirector.currentState == GameState.Selecting)
        {
            UpdateHighlight();
        }
    }

    public void ShowOptions(List<Option> options)
    {
        gameDirector.SetGameState(GameState.Selecting);
        // 清除舊的選項按鈕
        foreach (Transform child in optionContainer)
        {
            Destroy(child.gameObject);
        }

        // 清除舊的選擇中索引（將預設選擇中恢復為第一個）
        selectedOptionIndex = 0;

        // 清除最長按鈕寬度
        maxButtonWidth = 0;

        // 為每個選項創建一個新的按鈕
        foreach (Option option in options)
        {
            // 用模板創建一個物件交給optionObj變量來引用，並將他設為optionContainer的子物件。
            GameObject optionObj = Instantiate(optionObjPrefab, optionContainer);

            // 取得生成好的物件的按鈕組件的引用，加到一個清單中，以便之後控制選擇操作。
            Button optionButton = optionObj.GetComponent<Button>();
            optionsButtons.Add(optionButton);

            // 取得text子組件並更新它的值
            TextMeshProUGUI panelText = optionObj.GetComponentInChildren<TextMeshProUGUI>();
            panelText.text = option.Text;

            // 計算出適應文字後的按鈕寬度 (取得文字的首選寬度，然後添加一些緩衝像是 20)
            float preferredWidth = panelText.preferredWidth + 20;

            // 儲存最長的按鈕的寬度
            if (preferredWidth > maxButtonWidth)
            {
                maxButtonWidth = preferredWidth;
            }
        }

        // 將每個按鈕的長度統一為最長按鈕的寬度
        foreach (Button button in optionsButtons)
        {
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(maxButtonWidth, button.GetComponent<RectTransform>().sizeDelta.y);
        }
    }

    public void SelectNext()
    {
        if (selectedOptionIndex < optionsButtons.Count - 1)
        {
            selectedOptionIndex++;
        }
        else
        {
            selectedOptionIndex = 0;
        }
        Debug.Log("現在選擇中的選項為" + selectedOptionIndex);
    }

    public void SelectPrevious()
    {
        if (selectedOptionIndex == 0)
        {
            selectedOptionIndex = optionsButtons.Count - 1;
        }
        else
        {
            selectedOptionIndex--;
        }
        Debug.Log("現在選擇中的選項為" + selectedOptionIndex);
    }

    // 用迴圈設定每個按鈕的顏色
    // 其中 optionsButtons[selectedOptionIndex] 的底色設為高亮顏色
    void UpdateHighlight()
    {
        for (int i = 0; i < optionsButtons.Count; i++)
        {
            if (i == selectedOptionIndex)
            {
                optionsButtons[i].image.color = hightlightColor;
            }
            else
            {
                optionsButtons[i].image.color = normalColor;
            }
        }
    }
}
