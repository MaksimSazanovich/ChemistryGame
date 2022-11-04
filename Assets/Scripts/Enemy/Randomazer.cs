using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Randomazer : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] static private int numberOfRandom;

    Generator generator;

    int nowSprite = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        generator = FindObjectOfType<Generator>();

        
    }

    public void GetRandom()
    {
        nowSprite = Random.Range(0, sprites.Length - numberOfRandom);
        Sprite sprite = sprites[nowSprite];
        spriteRenderer.sprite = sprite;
    }

    public void GetSpriteName() => generator.MixAtoms(nowSprite);

    public void GetNumberOfRandom(int i)
    {
        switch (i)
        {
            case 1:
                numberOfRandom = 7;
                break;
            case 2:
                numberOfRandom = 6;
                break;

        }
    }
}
