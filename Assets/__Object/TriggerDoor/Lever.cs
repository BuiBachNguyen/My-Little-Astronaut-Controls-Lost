using System.Collections;
using UnityEngine;

public class Lever : MonoBehaviour
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
        if(collision.gameObject.CompareTag(Tag.Player))
        {
            isTriggered = true;
            animator.SetBool("isActivated", isTriggered);
            StartCoroutine(Wait());
        }    
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject go in doors)
        {
            go.SetActive(false);
        }
    }    
}
