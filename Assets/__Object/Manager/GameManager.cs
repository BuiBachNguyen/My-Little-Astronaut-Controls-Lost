using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    private void Start()
    {
        if (Instance != null && Instance != this)
        { 
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    #endregion

    [SerializeField] int diamon;
    [SerializeField] int deadCounter;
    [SerializeField] int choosenSkin;

}
