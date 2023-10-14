using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    private static int nextId = 0;
    public int id;

    public DialogueNode()
    {
        id = nextId++;
    }

    public List<Sentence> Sentences;
    public List<Option> Options;
}

[System.Serializable]
public class Sentence
{
    public string Name;
    public string Text;
}

[System.Serializable]
public class Option
{
    public string Text;
    public int NextNodeId;  // 指向下一個節點的ID
}
