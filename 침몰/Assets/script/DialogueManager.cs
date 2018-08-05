using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//이 클래스는 캐릭터별로 적용할 수 있다.
public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentences; //대화 내용 
    public Text nameText;//대화창: 이름
    public Text dialogueText;//대화창 : 대화

 
    void Start()
    {
        sentences = new Queue<string>(); //size를 입력하면 Element0~~~~ 이렇게 생성됨
    }

    void Update()
    {

    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
