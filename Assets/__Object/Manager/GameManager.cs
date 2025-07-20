using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField] int diamond;
    [SerializeField] int deadCounter;
    [SerializeField] int choosenSkin;

    public UnityAction<int> OnDiamondChanged;
    public UnityAction<int> OnDeadCounterChanged;
    public UnityAction<int> OnSkinChanged;

    public void SetDiamond(int value)
    {
        diamond = value;
        OnDiamondChanged?.Invoke(diamond);
    }

    public void SetDeadCounter(int value)
    {
        deadCounter = value;
        OnDeadCounterChanged?.Invoke(deadCounter);
    }

    public void SetChoosenSkin(int value)
    {
        choosenSkin = value;
        OnSkinChanged?.Invoke(choosenSkin);
    }

    public int GetDiamond() => diamond;
    public int GetDeadCounter() => deadCounter;
    public int GetChoosenSkin() => choosenSkin;
}

