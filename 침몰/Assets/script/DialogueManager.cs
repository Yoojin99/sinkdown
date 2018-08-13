using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //UI : 이름칸, 대화칸
    public Text nameText;
    public Text dialogueText;

    //대화 Queue
    private Queue<Dialogue> sentences;

    //대화창을 움직이게 하는 애니메이터
    public Animator animator;

    
    void Start()
    {
        sentences = new Queue<Dialogue>();
    }
    
    //대화 시작 + 첫 문장 출력
    public void StartDialogue (Dialogue[] dialogue)
    {
        animator.SetBool("IsOpen", true); //open the dialogue box
        
        sentences.Clear();

        foreach(Dialogue sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    //다음 문장 출력
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        Dialogue sentence = sentences.Dequeue();
        nameText.text = sentence.name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence.sentences));
    }

    //문장 출력 시 글자를 한개씩 나오게 만드는 효과
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;

        }
    }

    //대화 종료
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}