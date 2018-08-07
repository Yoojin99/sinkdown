using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //UI : 이름칸, 대화칸
    public Text nameText;
    public Text dialogueText;
    
    //대화 큐
    private Queue<Dialogue> sentences;

    //
    public Animator animator;

    
    void Start()
    {
        sentences = new Queue<Dialogue>();
    }
    
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

    //글자를 한개씩 나오게 만드는 효과
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;

        }
    }


    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}