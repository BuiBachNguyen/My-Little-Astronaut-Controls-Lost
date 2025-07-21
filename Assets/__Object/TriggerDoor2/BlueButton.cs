using System.Collections;
using UnityEngine;

public class BlueButton : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] bool isTriggered = false;
    [SerializeField] Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Player)
            || collision.gameObject.CompareTag(Tag.TriggerBlock))
        {
            isTriggered = true;
            animator.SetBool("isTriggering", isTriggered);
            StartCoroutine(Wait(isTriggered));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Player)
            || collision.gameObject.CompareTag(Tag.TriggerBlock))
        {
            isTriggered = true;
            animator.SetBool("isTriggering", isTriggered);
            StartCoroutine(Wait(isTriggered));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Player)
            || collision.gameObject.CompareTag(Tag.TriggerBlock))
        {
            isTriggered = false;
            animator.SetBool("isTriggering", isTriggered);
            StartCoroutine(Wait(isTriggered));
        }
    }
    IEnumerator Wait(bool value)
    {
        yield return new WaitForSeconds(0.25f);
        foreach (GameObject go in doors)
        {
            go.SetActive(!value);
        }
    }
}
