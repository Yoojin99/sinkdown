using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//이 클래스는 캐릭터별로 적용할 수 있다.
public class DialogueManager : MonoBehaviour
{
    public Queue<Dialogue> sentences; 
    public Text nameText;//대화창: 이름
    public Text dialogueText;//대화창 : 대화
    
    void Start()
    {
        sentences = new Queue<Dialogue>();
    }

    void Update()
    {

    }

    public void StartDialogue(Dialogue[] dialogue)
    {
     
        foreach (Dialogue sentence in dialogue)
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

        string sentence = sentences.Dequeue().sentences;
        string name = sentences.Dequeue().name;
        dialogueText.text = sentence;
        nameText.text = name;
        
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
