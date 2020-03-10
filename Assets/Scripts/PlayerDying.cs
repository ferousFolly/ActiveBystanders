using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerDying : MonoBehaviour
{
    public Image Injured;
    public Image dying;

    private bool enterColider = false;
    public float MaxsHealth = 100.0f;
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

        if (!alive)
        {
            return;
        }

        if (CurrentHealth <= 0) //Die
        {
            CurrentHealth = 0;
            alive = false;
        }

        if (CurrentHealth <= 20)
        {
            colorDying = 1;
        }
        colorInjury = 1;

        Injured.color = new Color(1,1,1,colorInjury);
        dying.color = new Color(1, 1, 1, colorDying);

        CurrentHealth -= amount;


    }

    public void Update()
    {
        if (CurrentHealth > MaxsHealth)
        {
            CurrentHealth = MaxsHealth;
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







