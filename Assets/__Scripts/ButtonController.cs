using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    #region Singleton
    public static ButtonController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    #endregion


    #region Climb Events
    public UnityAction<bool> OnClimbPressed;
    public void ClimbClick()
    {
        OnClimbPressed?.Invoke(true);
    }
    public void ClimbRelease()
    {
        OnClimbPressed?.Invoke(false);
    }
    #endregion

    #region LeftClick Events
    public UnityAction<bool> OnLeftButtonPressed;
    public void LeftButtonClick()
    {
        OnLeftButtonPressed?.Invoke(true);
    }    
    public void LeftButtonRelease()
    {
        OnLeftButtonPressed?.Invoke(false);
    }
    #endregion

    #region RightClick Events
    public UnityAction<bool> OnRightButtonPressed;

    public void RightButtonClick()
    {
        OnRightButtonPressed?.Invoke(true);
    }
    public void RightButtonRelease()
    {
        OnRightButtonPressed?.Invoke(false);
    }
    #endregion

    #region JumpClick Events
    public UnityAction<bool> OnJumpButtonPressed;
    public void JumpButtonClick()
    {
        OnJumpButtonPressed?.Invoke(true);
    }

    public void JumpButtonRelease()
    {
        OnRightButtonPressed?.Invoke(false);
    }
    #endregion
}
