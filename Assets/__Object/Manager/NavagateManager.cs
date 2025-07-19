using UnityEngine;

public class NavagateManager : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject other;

    public void SwitchPanel()
    {
        other.SetActive(true);
        mainPanel.SetActive(false);
    }    

    public void ReturnMainPanel()
    {
        mainPanel.SetActive(true);
        other.SetActive(false);
    }    

}
