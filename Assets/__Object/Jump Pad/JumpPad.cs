using UnityEngine;

public class JumpPad : MonoBehaviour
{
    Animator animator;
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
            Rigidbody2D col = collision.gameObject.GetComponent<Rigidbody2D>();
            col.AddForce(Vector2.up * 15.0f, ForceMode2D.Impulse);
            animator.SetBool("isActive", true);
        }    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Player))
        {
            animator.SetBool("isActive", false);
        }
    }
}
