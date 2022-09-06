using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
public class SpriteManager : MonoBehaviour
{
    [SerializeField] private SpriteLibraryAsset[] weapons_Behind, clothes, hands, eyes, faces, hair, weapons_Front;
    [SerializeField] private string[] testString;
    private SpriteLibraryAsset[][] assetLibrary = new SpriteLibraryAsset[7][];
    private SpriteLibraryAsset[] selectedLibAssets;
    [SerializeField] public SpriteLibraryAsset base_Character, new_Player_Character;
    private CreateCharacterVisuals createCharacterVisuals;
    private SpriteCombinder spriteCombinder;
    private UpdateAnimationLibrary updateAnimationLibrary;
    [SerializeField] private Sprite[] spriteArray;
    [SerializeField] private bool updateGraphics;
    [SerializeField] private SpriteLibrary playerLibrary;

    // Start is called before the first frame update
    void Start()
    {
        assetLibrary[0] = weapons_Behind;
        assetLibrary[1] = clothes;
        assetLibrary[2] = hands;
        assetLibrary[3] = eyes;
        assetLibrary[4] = faces;
        assetLibrary[5] = hair;
        assetLibrary[6] = weapons_Front;

        selectedLibAssets = findNewLibAssets(testString);

        createCharacterVisuals = GetComponent<CreateCharacterVisuals>();
        spriteCombinder = GetComponent<SpriteCombinder>();
        updateAnimationLibrary = GetComponent<UpdateAnimationLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        if (updateGraphics)
        {
            selectedLibAssets = findNewLibAssets(testString);
            spriteArray = createCharacterVisuals.loadNewGraphicsFromLibraries(selectedLibAssets);
            UpdateSpriteLibrary(playerLibrary, new_Player_Character, spriteArray);
            updateGraphics = false;
        }
    }

    public SpriteLibraryAsset FindSpriteLibAsset()
    {
        
        return base_Character;
    }

    public SpriteLibraryAsset[] findNewLibAssets(string[] stringArray)//array of items/clothes/facial features being applied to the player.
    {                                                                 //this string array should always match the number of elements in assetLibrary Array
        List<SpriteLibraryAsset> libraryAssets = new List<SpriteLibraryAsset>();

        for (int i = 0; i < assetLibrary.Length; i++)
        {
            foreach (var item in assetLibrary[i])
            {
                if(stringArray[i] == item.name) {
                    libraryAssets.Add(item);
                }
                
            }
        }

        return libraryAssets.ToArray();
    }


    public void UpdateSpriteLibrary(SpriteLibrary spriteLibrary, SpriteLibraryAsset libraryAsset, Sprite[] newSpriteArray)
    {
        foreach (var sprite in newSpriteArray)
        {
            libraryAsset.AddCategoryLabel(sprite, "Run_Down", sprite.name.ToString());
        }
        Debug.Log("updated sprite library");
        spriteLibrary.spriteLibraryAsset = libraryAsset;
    }
    public void UpdateSpriteLibraryToDefault(SpriteLibrary spriteLibrary)
    {
        spriteLibrary.spriteLibraryAsset = base_Character;
    }



    //Maybe have a function that grabs all spriteLibraryAssets in SpriteLibrary and sticks them in the arrays.
}
