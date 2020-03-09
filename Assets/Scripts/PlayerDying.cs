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

    public bool alive = true;
    // Start is called before the first frame update
    private void Start()
    {
        alive = true; //player strts off as alive 
        CurrentHealth = MaxHealth;


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            enterColider = true;

        Debug.Log("im hit");
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            enterColider = false;
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
            gameObject.SetActive(false);
        }


        CurrentHealth -= amount;


    }

    public void Update()
    {
        //HEALTH COUNT DOWN
        if (MaxHealth > 0 && enterColider == true)
        {
            MaxHealth -= Time.deltaTime;
        }

        if (MaxHealth >= 0 && enterColider == false)
        {
            MaxHealth += Time.deltaTime;
        }

        if (MaxHealth > MaxsHealth)
        {
            MaxHealth = MaxsHealth;
        }
    }

}


//public void OnGUI()
//{
//    if (MaxHealth <= 100)
//    {
//        UI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), Injured);
//    }

//    if (MaxHealth <= 50)
//    {
//        GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), dying);

//    }

    // Update is called once per frame





