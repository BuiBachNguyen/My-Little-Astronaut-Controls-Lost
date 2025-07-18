using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class GameData
{
    public int deathCounter;
    public int indexOfSkin;
    public List<SpriteLibraryAsset> _assets;

    public GameData()
    {
        this.deathCounter = 0;
    }

    void CheckData()
    {
        if (deathCounter <= 0) deathCounter = 1;
        int sizeLib = _assets.Count;
        if(0 < indexOfSkin || indexOfSkin > sizeLib - 1)
        {
            indexOfSkin = 0;
        }    
    }
}
