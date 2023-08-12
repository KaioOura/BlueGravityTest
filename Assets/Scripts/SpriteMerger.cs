using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMerger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] spritesToMerge;
    
    [SerializeField]
    private SpriteRenderer _spriteRenderer;


    public Sprite _finalSprite;
    // Start is called before the first frame update
    void Start()
    {
        Merge();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Merge()
    {
        Resources.UnloadUnusedAssets();
        
        var newTex = new Texture2D(512, 512);

        for (int i = 0; i < newTex.width; i++)
        {
            for (int j = 0; j < newTex.height; j++)
            {
                newTex.SetPixel(i,j, new Color(1,1,1,0));
            }
        }

        for (int i = 0; i < spritesToMerge.Length; i++)
        {
            for (int j = 0; j < spritesToMerge[i].texture.width; j++)
            {
                for (int k = 0; k < spritesToMerge[i].texture.width; k++)
                {
                    var color = spritesToMerge[i].texture.GetPixel(j, k).a == 0
                        ? newTex.GetPixel(j, k)
                        : spritesToMerge[i].texture.GetPixel(j, k);
                    
                    newTex.SetPixel(j,k, color);
                }
            }
        }
        
        newTex.Apply();
        var finalSprite = Sprite.Create(newTex, new Rect(0, 0, newTex.width, newTex.height), new Vector2(0.512f, 0.512f));
        finalSprite.name = "new Sprite";
        _finalSprite = finalSprite;
        _spriteRenderer.sprite = finalSprite;
    }
}
