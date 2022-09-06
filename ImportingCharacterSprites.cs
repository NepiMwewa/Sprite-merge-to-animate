using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportingCharacterSprites : MonoBehaviour
{
    public bool changeSprite, changeSpriteBack;
    public UnityEngine.U2D.Animation.SpriteLibrary spritelibrary;
    public UnityEngine.U2D.Animation.SpriteLibraryAsset newSpriteLibAsset, baseSprite;
    public Sprite[] testSprite;
    //public Texture2D textureSprite;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (changeSprite)
        {

            changeSprite = false;
            CloneLib();
        }
    }



    public void CloneLib()
    {
        //Grab testsprite and put it on each
        foreach (var sprite in testSprite)
        {
            newSpriteLibAsset.AddCategoryLabel(sprite, "Run_Down", sprite.name.ToString());
        }

        spritelibrary.spriteLibraryAsset = newSpriteLibAsset;

    }

    /*
    static void CreateLib()
    {
        const string spriteLibName = "MySpriteLib.asset";

        var spriteLib = ScriptableObject.CreateInstance<SpriteLibraryAsset>();
        spriteLib.AddCategoryLabel(null, "Cat", "Label");

        AssetDatabase.CreateAsset(spriteLib, "Assets/" + spriteLibName);
    }
    */
}
