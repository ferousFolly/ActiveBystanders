using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class AIDying : MonoBehaviour
{

    public Animator Damage;
    public Animator Death;
    public float MaxHealth = 100f;
    public float CurrentHealth = 0f;
   


    public bool alive = true;
    private void Start()
    {
        alive = true; //player strts off as alive 
        CurrentHealth = MaxHealth;
        
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

            GetComponent<Animator>();
            if (Death != null)
            {
                Death.applyRootMotion = true;
            }
                  
        }

        if (CurrentHealth <= 20)
        {
            GetComponent<Animator>();
            if(Damage != null)
            {
                Damage.applyRootMotion = true;
            }
        }
       
         CurrentHealth -= amount;


    }

    public void Update()
    {
      

        Debug.Log(CurrentHealth);
        //HEALTH COUNT DOWN

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

    }

}