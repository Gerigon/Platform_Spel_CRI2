using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Health : MonoBehaviour {

    private int maxHeartAmount = 5;
    public int curHealth;
    private int maxHealth;
    private int healthPerHeart = 2;

				public Player player;
    public Image[] heartImages;
    public Sprite[] heartSprites;

	// Use this for initialization
	void Start ()
    {
		curHealth = GameManager.instance.player.GetComponent<Player>().health;
        maxHealth = maxHeartAmount * healthPerHeart;
        SetHealth();

    }
	
    void SetHealth()
    {
        for (int i = 0; i < maxHeartAmount; i++)
        { 
            if (Mathf.Ceil((float)curHealth / 2) <= i)
            {
                heartImages[i].enabled = false;
            }
            else
            {
                heartImages[i].enabled = true;
            }
        }
        UpdateHearts();
    }

    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in heartImages)
        {
            if (empty)
            {
                image.sprite = heartSprites[0];
            }
            else
            {
                i++;
                if(curHealth>= i*healthPerHeart)
                {
                    image.sprite = heartSprites[heartSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - curHealth));
                    int healthPerImage = healthPerHeart / (heartSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = heartSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

    public void TakeDamage(int value)
    {
        curHealth = player.health;
        UpdateHearts();
    }


	// Update is called once per frame
	void Update () {
		
	}
}
