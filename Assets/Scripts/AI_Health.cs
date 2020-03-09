using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AI_Health : MonoBehaviour
{

    public Text AI_H;
    public float AI_MaxH = 200f;
    public float AI_CurH = 0f;
    public bool AI_alive = true;
    // Start is called before the first frame update
    void Start()
    {
        AI_alive = true;
        AI_CurH = AI_MaxH;
        SetHealthBar();

    }

    private void Update()
    {
        AI_H.text = "AI_H" + AI_MaxH.ToString();
        if ( AI_MaxH >= 0)
        {
           
            SceneManager.LoadScene("Winner");
        }
    }



    public void TakeDamage(float amount)
    {

        if (!AI_alive)
        {
            return;
        }

        if (AI_CurH <= 0)
        {
            AI_CurH = 0;
            AI_alive = false;
            gameObject.SetActive(false);
        }


        AI_CurH -= amount;
        SetHealthBar();

    }

    // Update is called once per frame
    void SetHealthBar()
    {
        float my_health = AI_CurH / AI_MaxH;
        AI_H.transform.localScale = new Vector3(Mathf.Clamp(my_health, 0f, 1f), AI_H.transform.localScale.y, AI_H.transform.localScale.x);


    }




}