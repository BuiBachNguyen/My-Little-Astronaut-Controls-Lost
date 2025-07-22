using UnityEngine;

public class PortalIn : MonoBehaviour
{
    [SerializeField] GameObject portalOut;
    [SerializeField] float modifyX, modifyY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(Tag.Player))
        {
            collision.gameObject.transform.position = portalOut.transform.position + new Vector3(modifyX, modifyY, 0f);
        }    
    }
}
