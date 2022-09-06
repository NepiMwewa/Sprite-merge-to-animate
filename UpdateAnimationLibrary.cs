using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class UpdateAnimationLibrary : MonoBehaviour
{

    //Use this script to facilatate changes within the animations. Such as change to a differente spriteasset when the player is at half health with 
    // blood on them.

    public bool changeSprite, changeSpriteBack;
    public SpriteLibrary localSpritelibrary;
    public SpriteLibraryAsset newSpriteLibAsset, baseSprite;
    public Sprite[] testSprite;
    //public Texture2D textureSprite;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(changeSprite)
        {

            changeSprite = false;
            SetLocalSpriteToNewSpriteLibAsset();
        }
        if (changeSpriteBack)
        {

            changeSpriteBack = false;
            SetSpriteLibAssetToBase();
        }
    }


       
    public void SetLocalSpriteToNewSpriteLibAsset()
    {
        //Grab testsprite and put it on each
        foreach (var sprite in testSprite)
        {
            newSpriteLibAsset.AddCategoryLabel(sprite, "Run_Down", sprite.name.ToString());
        }

        localSpritelibrary.spriteLibraryAsset = newSpriteLibAsset;

    }
    public void SetSpriteLibAssetToBase()
    {
        //set spritelibrary asset to base sprite lib asset
        localSpritelibrary.spriteLibraryAsset = baseSprite;
    }

}
