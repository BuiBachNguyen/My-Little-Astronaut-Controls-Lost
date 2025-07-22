using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TheTorch : MonoBehaviour
{
    [SerializeField] GameObject globalLight2D;
    [SerializeField] GameObject LoadIn;
    [SerializeField] DataGame gameData;
    [SerializeField] bool isTriggered = false;
    [SerializeField] Animator animator;

    private Light2D light2D;

    void Start()
    {
        if (globalLight2D != null)
            light2D = globalLight2D.GetComponent<Light2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            animator.SetBool("isTriggered", isTriggered);
            StartCoroutine(WaitForLight());
        }
    }

    public IEnumerator WaitForLight()
    {
        if (light2D == null)
            yield break;

        float duration = 2f;
        float elapsed = 0f;
        float startIntensity = light2D.intensity;
        float targetIntensity = 1f; 

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            light2D.intensity = Mathf.Lerp(startIntensity, targetIntensity, t);
            yield return null;
        }

        light2D.intensity = targetIntensity;
        gameData.level += 1;
        if (gameData.level >= 11) gameData.level = 0;
        LoadIn.SetActive(true);
    }
}
