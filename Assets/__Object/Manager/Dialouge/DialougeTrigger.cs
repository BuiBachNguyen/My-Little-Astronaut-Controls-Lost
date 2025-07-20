using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public GameObject DialogueManager;
    public Message[] messages;
    public Actor[] actors;
    private bool wasPlayed = false;
    //public Animator animator;
    [SerializeField] private float WaitTime = 1.5f;

    //
    public void StartDialogue()
    {
        if (wasPlayed) return;
        DialogueManager.SetActive(true);
        FindFirstObjectByType<DialougeManager>().OpenDialogue(messages, actors);
        wasPlayed = true;
        //animator.SetBool("isOn", true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))// && !wasPlayed)
        {
            StartCoroutine("Wait_Coroutine");
        }
    }

    public IEnumerator Wait_Coroutine()
    {
        yield return new WaitForSeconds(WaitTime);
        StartDialogue();
    }
}
[System.Serializable]
public class Message
{
    public int actorID;
    public string message;
}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
