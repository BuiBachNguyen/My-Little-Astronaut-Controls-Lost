using UnityEngine;
using UnityEngine.U2D.Animation;

public class SkinManager : MonoBehaviour
{
    [SerializeField] DataGame _dataGame;
    [SerializeField] PlayerController _playerController;
    [SerializeField] SpriteLibrary _library;
    void Start()
    {
        if (_playerController == null || _dataGame == null) return;
        _library = _playerController.GetComponent<SpriteLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        _library.spriteLibraryAsset = _dataGame._assets[_dataGame.indexOfSkin];
    }

    public void OnChangeTo(int index)
    {
        if (!(0 <= index && index <= 2)) index = 0;
        _dataGame.indexOfSkin = index;
        Debug.Log("Change");
    }    
}
