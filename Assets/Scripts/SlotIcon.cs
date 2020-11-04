using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotIcon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] slotIcons;
    private Sprite GenerateRandomSprite()
    {
        int randomIndex = Mathf.RoundToInt(Random.Range(0, slotIcons.Length));
        return slotIcons[randomIndex];
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = GenerateRandomSprite();
    }
}
