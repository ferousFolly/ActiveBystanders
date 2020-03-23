using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;



public class AIDying : MonoBehaviour
{

    private Animator _animation;

    public float MaxHealth = 100f;
    public float CurrentHealth = 0f;
    public bool alive = true;

    public void Awake()
    {
        
    }

     public void Hurt(AIDying HurtINFO)
    {

    }
    private void Start()
    {
        _animation = GetComponent<Animator>();
        alive = true; //player strts off as alive 
        CurrentHealth = MaxHealth;
    }

    public void TakeDamageAI(float amount)
    {

        if (!alive)
        {
            return;
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            alive = false;
            GetComponent<Animator>().enabled = false;

        }


            if (CurrentHealth <= 20)
        {
            _animation.Play("Damage", 0, 0);

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