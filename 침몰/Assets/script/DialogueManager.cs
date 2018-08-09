using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//이 클래스는 캐릭터별로 적용할 수 있다.
public class DialogueManager : MonoBehaviour
{
<<<<<<< HEAD
    //UI : 이름칸, 대화칸
    public Text nameText;
    public Text dialogueText;

    //대화 Queue
    private Queue<Dialogue> sentences;

    //대화창을 움직이게 하는 애니메이터
    public Animator animator;

=======
    public Queue<Dialogue> sentences; 
    public Text nameText;//대화창: 이름
    public Text dialogueText;//대화창 : 대화
>>>>>>> 723fe26e0fb87c880964ac0771dcbf4d4208db41
    
    void Start()
    {
        sentences = new Queue<Dialogue>();
    }
<<<<<<< HEAD
    
    //대화 시작 + 첫 문장 출력
    public void StartDialogue (Dialogue[] dialogue)
=======

    void Update()
>>>>>>> 723fe26e0fb87c880964ac0771dcbf4d4208db41
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

    //다음 문장 출력
    public void DisplayNextSentence()
    {
        
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
<<<<<<< HEAD
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
=======
>>>>>>> 723fe26e0fb87c880964ac0771dcbf4d4208db41

        string sentence = sentences.Dequeue().sentences;
        string name = sentences.Dequeue().name;
        dialogueText.text = sentence;
        nameText.text = name;
        
    }

<<<<<<< HEAD
    //대화 종료
=======
>>>>>>> 723fe26e0fb87c880964ac0771dcbf4d4208db41
    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
