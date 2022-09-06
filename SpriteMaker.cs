using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaker : MonoBehaviour
{
    SpriteRenderer rend;

    public Texture2D[] textureArray;
    private Texture2D tex;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        //make texture
        //tex = MakeTexture(textureArray);

        //make sprite
        //rend.sprite = MakeSprite(tex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Texture2D MakeTexture(Texture2D[] layers)
    {
        //BUG CHECK: if only one or no image layers are present
        if(layers.Length == 0)
        {
            Debug.LogError("No image layer information in array!");
            return Texture2D.whiteTexture;
        }else if (layers.Length == 1)
        {
            Debug.Log("Only one image layer present. Are you sure you need to make a texture?");
            return layers[0];
        }
        Resources.UnloadUnusedAssets();
        //create a texture
        Texture2D newTexture = new Texture2D(layers[0].width, layers[0].height);

        //array to store the destination texture's pixels
        Color[] colorArray = new Color[newTexture.width * newTexture.height];

        // array of colors derived from the source texture
        Color[][] adjustedLayers = new Color[layers.Length][];

        //populate array with cropped or expanded layer arrays
        for (int i = 0; i < layers.Length; i++)
        {   
            //if layer's width and height is equal to the base layer
            if (i == 0 || layers[i].width == newTexture.width && layers[i].height == newTexture.height)
            {
                adjustedLayers[i] = layers[i].GetPixels();
            }//else crop the larger image or center the smaller image on the layer.
            else
            {
                int getX, getWidth, setX, setWidth;

                getX = (layers[i].width > newTexture.width) ? (layers[i].width - newTexture.width) / 2  : 0;
                getWidth = (layers[i].width > newTexture.width) ? newTexture.width : layers[i].width;
                setX = (layers[i].width < newTexture.width) ? (newTexture.width - layers[i].width) / 2: 0;
                setWidth = (layers[i].width < newTexture.width) ? layers[i].width : newTexture.width;

                int getY, getHeight, setY, setHeight;

                getY = (layers[i].height > newTexture.height) ? (layers[i].height - newTexture.height) / 2 : 0;
                getHeight = (layers[i].height > newTexture.height) ? newTexture.height : layers[i].height;
                setY = (layers[i].height < newTexture.height) ? (newTexture.height - layers[i].height) / 2 : 0;
                setHeight = (layers[i].height < newTexture.height) ? layers[i].height : newTexture.height;


                Color[] getPixels = layers[i].GetPixels(getX, getY, getWidth,getHeight);
                if (layers[i].width >= newTexture.width && layers[i].height >= newTexture.height)
                {
                    adjustedLayers[i] = getPixels;
                }
                else
                {
                    Texture2D sizedLayer = ClearTexture(newTexture.width, newTexture.height);
                    sizedLayer.SetPixels(setX, setY, setWidth, setHeight, getPixels);

                    adjustedLayers[i] = sizedLayer.GetPixels();
                }
            }
        }

        //iterate through each pixel, copying the source index to the destination index
        for (int x = 0; x < newTexture.width; x++)
        {
            for (int y = 0; y < newTexture.height; y++)
            {
                int pixelIndex = x + (y * newTexture.width);
                for (int i = 0; i < layers.Length; i++)
                {
                    Color srcPixel = adjustedLayers[i][pixelIndex];

                    //Normal blending based on alpha
                    if (srcPixel.a == 1)
                    {
                        colorArray[pixelIndex] = srcPixel;
                    } else if (srcPixel.a > 0)
                    {
                        colorArray[pixelIndex] = NormalBlend(colorArray[pixelIndex], srcPixel);
                    }
                }
            }
        }

        //transfert the array to the texture and apply the pixels
        newTexture.SetPixels(colorArray);
        newTexture.Apply();

        //confirm any settings
        newTexture.wrapMode = TextureWrapMode.Clamp;
        newTexture.filterMode = FilterMode.Point;

        return newTexture;
    }
    public Sprite MakeSprite(Texture2D texture)
    {
        //create create a sprite from that texture
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f, 32);
    }

    public Color NormalBlend(Color dest, Color src)
    {
        float srcAlpha = src.a;
        float destAlpha = (1 - srcAlpha) * dest.a;
        Color destLayer = dest * destAlpha;
        Color srcLayer = src * srcAlpha;
        return destLayer + srcLayer;
    }

    private Texture2D ClearTexture(int width, int height)
    {
        Texture2D clearTexture = new Texture2D(width, height);
        Color[] clearPixels = new Color[width * height];
        clearTexture.SetPixels(clearPixels);
        return clearTexture;
    }
}
