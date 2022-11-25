using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 packagePickedUpColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 packageNotPickedUpColor = new Color32(1, 1, 1, 1);

    bool packagePickedUp;

    SpriteRenderer spriteRenderer;

    private void setColour(SpriteRenderer spriteRenderer, Color32 colour)
    {
        spriteRenderer.color = colour;
    }

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !packagePickedUp)
        {
            Debug.Log("Package picked up");
            packagePickedUp = true;
            setColour(spriteRenderer, packagePickedUpColor);
            Destroy(other.gameObject, destroyDelay);
        } 
        else if (other.tag == "Customer" && packagePickedUp)
        {
            Debug.Log("Package delivered");
            packagePickedUp = false;
            setColour(spriteRenderer, packageNotPickedUpColor);
        }
    }
}
