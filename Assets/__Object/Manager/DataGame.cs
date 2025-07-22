using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "DataGame", menuName = "Scriptable Objects/DataGame")]
public class DataGame : ScriptableObject
{
    public int maxlevel = 100;
    public int level = 1;
    public bool isDead;
    public int indexOfSkin = 0;
    public float scaleOfSFX = 1;
    //public float scaleOfLight = 1;
    public List<SpriteLibraryAsset> _assets;
    public List<Sprite> _sprites;
    private void Awake()
    {
        level = 1;
    }
}
