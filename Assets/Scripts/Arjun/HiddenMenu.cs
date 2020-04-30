using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HiddenMenu : MonoBehaviour
{

    private string[] cheatCode;
    private int index;
    private bool cheat;
    public GameObject AI;
    public GameObject FrontDoor;
    public GameObject Note1;
    public GameObject Note2;
    public GameObject Note3;
    public GameObject Note4;
    public GameObject Note5;
    public GameObject Note6;
    public GameObject Note8;
    public GameObject Note7;

    void OnGUI()
    {
        if (cheat)
        {
            // draw the hidden menu
            GUI.Box(new Rect(20, 80, 240, 240), "Paraception Dev Menu");
            if (GUI.Button(new Rect(40, 120, 200, 20), "Reset Scene"))
            { 
                SceneManager.LoadScene("GamePlayScene");
            }
            if (GUI.Button(new Rect(40, 150, 200, 20), "Disable AI"))
            {
                AI.SetActive(false);
            }
            if (GUI.Button(new Rect(40, 180, 200, 20), "Enable AI"))
            {
                AI.SetActive(true);
            }
            if (GUI.Button(new Rect(40, 210, 200, 20), "Unlock Front Door"))
            {
                FrontDoor.SetActive(false);
            }
            if (GUI.Button(new Rect(40, 240, 200, 20), "Collectitems"))
            {
                Note1.SetActive(true);
                Note2.SetActive(true);
                Note3.SetActive(true);
                Note4.SetActive(true);
                Note5.SetActive(true);
                Note6.SetActive(true);
                Note7.SetActive(true);
            }
            if (GUI.Button(new Rect(40, 270, 200, 20), "Play Credits"))
            {
                SceneManager.LoadScene("Ending");
            }
            if (GUI.Button(new Rect(40, 300, 200, 20), "Close this menu"))
            {
                cheat = false;
                index = 0;
            }
        }
    }

    void Start()
    {
        cheatCode = new string[] {
   "s",
   "e",
   "c",
   "r",
   "e",
   "t"
  };
        index = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Application.Quit();
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                // right input, check next digit
                index++;
            }
            else
            {
                // wrong input, restart from index 0
                index = 0;
            }
        }

        if (index == cheatCode.Length)
        {
            cheat = true;
            index = 0;
        }
    }
}
