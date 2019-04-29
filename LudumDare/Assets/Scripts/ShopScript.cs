using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour {

    public SpriteRenderer[] itemsSpawnSpots;
    public float GizmosSize;
    public BaseAttack[] possibleItems;

    public Texture2D tex;
    public Sprite mySprite;


	void Start () {
        SpawnItems();
	}

    void SpawnItems ()
    {
        for (int i = 0; i < itemsSpawnSpots.Length; i++)
        {
            BaseAttack myItem = possibleItems[Random.Range(0, possibleItems.Length)];
            itemsSpawnSpots[i].sprite = myItem.UIElement;
            itemsSpawnSpots[i].gameObject.GetComponent<PlayerPickUpTheThing>().myAttack = myItem;
        }
    }
	
}
