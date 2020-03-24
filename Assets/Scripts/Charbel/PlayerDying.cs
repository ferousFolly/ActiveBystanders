using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerDying : MonoBehaviour
{
    public Image Injured;
    public Image dying;
    public GameObject GameOver;

    public float MaxHealth = 100f;
    public float CurrentHealth = 0f;

    
    float colorInjury = 0f;
    float colorDying = 0f;

    public bool alive = true;
    private void Start()
    {
        alive = true; //player strts off as alive 
        CurrentHealth = MaxHealth;

        colorInjury = Injured.color.a;
        colorDying = dying.color.a;
       
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;

        if (!alive)
        {
            return;
      
        }
        if (CurrentHealth <= 0) //Die
        {
            GameOver.SetActive(true);
            alive = false;   

        }
        if(CurrentHealth <=0)
        {
            alive = false;
        }

        if (CurrentHealth <= 60)
        {
            colorDying = 1;


        }
        else if(CurrentHealth > 60)
        {

            colorInjury = 1;

        }


        Injured.color = new Color(1,1,1,colorInjury);
        dying.color = new Color(1, 1, 1, colorDying);
    }

    public void Update()
    {
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        if (colorInjury > 0) {
            colorInjury -= Time.deltaTime * 1.1f;
        }
        if (colorDying > 0)
        {
            colorDying -= Time.deltaTime * 1.1f;
        }
        
        Injured.color = new Color(1, 1, 1, colorInjury);
        dying.color = new Color(1, 1, 1, colorDying);

    }

}







