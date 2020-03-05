using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
   
    public Text Health;
    public float MaxH = 100f;
    public float CurH = 0f;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        CurH = MaxH;
        SetHealthBar ();
        
    }

    private void Update()
    {
        Health.text = "Health" + MaxH.ToString();
        if (MaxH >= 0)
        {
            SceneManager.LoadScene("Winner");
        }
    }

    public void TakeDamage(float amount)
    {

        if(!alive)
        {
            return;
        }

        if (CurH <=0)
        {
            CurH = 0;
            alive = false;
            gameObject.SetActive(false);
        }


        CurH -= amount;
        SetHealthBar();
        
    }

    // Update is called once per frame
    void SetHealthBar ()
    {
        float my_health = CurH / MaxH;
        Health.transform.localScale = new Vector3(Mathf.Clamp(my_health, 0f, 1f), Health.transform.localScale.y, Health.transform.localScale.x);

        
    }



    
}
