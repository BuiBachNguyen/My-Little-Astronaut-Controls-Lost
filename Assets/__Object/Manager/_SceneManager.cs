using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    [SerializeField] DataGame _dataGame;

    [SerializeField] GameObject LoadIn;
    [SerializeField] GameObject LoadOut;

    public void LoadOutEnable()
    {
        LoadOut.SetActive(true);
    }   
    
    public void LoadInEnable()
    {
        LoadIn.SetActive(true);
    }
    public void LoadOutDisable()
    {
        LoadOut.SetActive(false);
    }
    public void LoadInDisable()
    {
        LoadIn.SetActive(false);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(_dataGame.level);
    }

    void LoadSelectedScene(int level)
    {
        _dataGame.level = level - 1;
        if(level >= _dataGame.maxlevel) _dataGame.level = _dataGame.maxlevel;
        else if(level <= 0) _dataGame.level = 0;
        LoadOutEnable();
    }    
    void ReloadWhenDie()
    {
        _dataGame.level -= 1;
        LoadOutEnable();
    }    

    void NextScene()
    {
        _dataGame.level += 1;
        LoadInEnable();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Select_Level");
    }    
}
