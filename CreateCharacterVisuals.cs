using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class CreateCharacterVisuals : MonoBehaviour
{
    [SerializeField] private SpriteCombinder spriteCombinder;

    public Texture2D[] testSprite;
    private Sprite[] clotheSprites, handSprites, faceSprites, eyeSprites, hairSprites, finishedSprites;
    public SpriteLibraryAsset clotheAsset, handAsset, faceAsset, eyeAsset, hairAsset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Sprite[] loadNewGraphics()
    {
        clotheSprites = new Sprite[8];
        handSprites = new Sprite[clotheSprites.Length];
        faceSprites = new Sprite[clotheSprites.Length];
        eyeSprites = new Sprite[clotheSprites.Length];
        hairSprites = new Sprite[clotheSprites.Length];
        testSprite = new Texture2D[5];
        finishedSprites = new Sprite[clotheSprites.Length];

        for (int i = 0; i < clotheSprites.Length; i++)
        {
            clotheSprites[i] = clotheAsset.GetSprite("Run_Down", i.ToString());
            handSprites[i] = handAsset.GetSprite("Run_Down", i.ToString());
            faceSprites[i] = faceAsset.GetSprite("Run_Down", i.ToString());
            eyeSprites[i] = eyeAsset.GetSprite("Run_Down", i.ToString());
            hairSprites[i] = hairAsset.GetSprite("Run_Down", i.ToString());


            testSprite[0] = SpriteToTexture2D(clotheSprites[i]);
            testSprite[1] = SpriteToTexture2D(handSprites[i]);
            testSprite[2] = SpriteToTexture2D(faceSprites[i]);
            testSprite[3] = SpriteToTexture2D(eyeSprites[i]);
            testSprite[4] = SpriteToTexture2D(hairSprites[i]);

            finishedSprites[i] = spriteCombinder.MakeSprite(spriteCombinder.MakeTexture(testSprite));
            finishedSprites[i].name = i.ToString();
        }


        //spriteRenderer.sprite = finishedSprites[whichItemToGet];

       return finishedSprites;

        //spriteRenderer.sprite = clotheSprites[whichItemToGet];
        // tex = spriteMaker.MakeTexture(testSprite);
        //Debug.Log("Sprite count: " + "spriteAtlas.spriteCount");

    }
    public Sprite[] loadNewGraphicsFromLibraries(SpriteLibraryAsset[] spriteLibraries)
    {
        testSprite = new Texture2D[5];
        finishedSprites = new Sprite[8];
        //grabs the sprites one at a time, merges them, and stores them in the finished sprites[i] array
        //for Run_Down Category
        for (int i = 0; i < 8; i++)
        {
            testSprite[0] = SpriteToTexture2D(spriteLibraries[1].GetSprite("Run_Down", i.ToString()));
            testSprite[1] = SpriteToTexture2D(spriteLibraries[2].GetSprite("Run_Down", i.ToString()));
            testSprite[2] = SpriteToTexture2D(spriteLibraries[3].GetSprite("Run_Down", i.ToString()));
            testSprite[3] = SpriteToTexture2D(spriteLibraries[4].GetSprite("Run_Down", i.ToString()));
            testSprite[4] = SpriteToTexture2D(spriteLibraries[5].GetSprite("Run_Down", i.ToString()));

            finishedSprites[i] = spriteCombinder.MakeSprite(spriteCombinder.MakeTexture(testSprite));
            finishedSprites[i].name = i.ToString();
        }

        
        //spriteRenderer.sprite = finishedSprites[whichItemToGet];

        return finishedSprites;

        //spriteRenderer.sprite = clotheSprites[whichItemToGet];
        // tex = spriteMaker.MakeTexture(testSprite);
        //Debug.Log("Sprite count: " + "spriteAtlas.spriteCount");

    }

    private Texture2D SpriteToTexture2D(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width || sprite.rect.height != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.rect.x,
                                                         (int)sprite.rect.y,
                                                         (int)sprite.rect.width,
                                                         (int)sprite.rect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }
}
