using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Health : MonoBehaviour {

    private int maxHeartAmount = 5;
    public int startHearts = 3;
    public int curHealth;
    private int maxHealth;
    private int healthPerHeart = 2;

    public Image[] heartImages;
    public Sprite[] heartSprites;

	// Use this for initialization
	void Start ()
    {
        curHealth = startHearts * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;
        SetHealth();

    }
	
    void SetHealth()
    {
        for (int i = 0; i < maxHeartAmount; i++)
        {
            if (startHearts <= i)
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
        curHealth -= value;
        curHealth = Mathf.Clamp(curHealth, 0, startHearts * healthPerHeart);
        UpdateHearts();
    }

    public void AddHeartContainer()
    {
        startHearts++;
        startHearts = Mathf.Clamp(startHearts, 0, maxHeartAmount);

        curHealth = startHearts * healthPerHeart;
        maxHealth = maxHeartAmount * healthPerHeart;

        SetHealth();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
