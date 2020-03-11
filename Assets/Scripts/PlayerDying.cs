using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerDying : MonoBehaviour
{
    public Image Injured;
    public Image dying;

    public float MaxHealth = 100f;
    public float CurrentHealth = 0f;
    public float colorIn = 0f;
    public float colorDying = 0f;
    

    public bool alive = true;
    private void Start()
    {
        alive = true; //player strts off as alive 
        CurrentHealth = MaxHealth;
        colorIn = Injured.color.a;
        colorDying = dying.color.a;
    }

    public void TakeDamage(float amount)
    {

        if (!alive)
        {
            return;
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            alive = false;
        }

        if (CurrentHealth <= 20)
        {
            colorDying = 1f;
            Debug.Log("sssss");
        }
        else {
            colorIn = 1;
        }



        dying.color = new Color(1,1,1,colorDying);
        Injured.color = new Color(1,1,1,colorIn);


         CurrentHealth -= amount;


    }

    public void Update()
    {
        if(colorIn>0)
        {
            colorIn -= Time.deltaTime* 0.5f;
        }
        else
        {
            colorDying -= Time.deltaTime* 1.1f;
        }
        dying.color = new Color(1, 1, 1, colorDying);
        Injured.color = new Color(1, 1, 1, colorIn);

        Debug.Log(CurrentHealth);
        //HEALTH COUNT DOWN
    
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

    }

}








