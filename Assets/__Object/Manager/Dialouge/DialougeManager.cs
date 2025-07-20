using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    public GameObject CanvasController;
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public bool isSkip;
    [SerializeField] public DataGame gameData;

    void Start()
    {
        isSkip = false;
        backgroundBox.transform.localScale = Vector3.zero;
    }
    void Update()
    {
    }

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        CanvasController.SetActive(false);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];

        actorName.text = actorToDisplay.name;
        if (actorToDisplay.name == "Little Astro")
        {
            actorImage.sprite = (gameData._sprites)[gameData.indexOfSkin];
        }
        else 
            actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }
    
    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            isSkip = true;
            SkipDialogue();
        }
    }
    public void SkipDialogue()
    {
        if (!isSkip)
        {
            activeMessage = currentMessages.Length - 1;
            DisplayMessage();
            isSkip = true;
        }
        else
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            StartCoroutine("Wait_Coroutine");
        }

    }
    public IEnumerator Wait_Coroutine()
    {
        yield return new WaitForSeconds(0.6f);
        backgroundBox.gameObject.SetActive(false);
        CanvasController.SetActive(true);
    }

    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }    
}
