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
                GameEventObserver.i.UnlockFrontDoor();
            }
            if (GUI.Button(new Rect(40, 240, 200, 20), "BurnRitualItems"))
            {
                GameEventObserver.i.isBurningItems = true;
            }
            if (GUI.Button(new Rect(40, 270, 200, 20), "CollectAllItems"))
            {
                InventoryManager.i.CollectAllItems();
            }
            if (GUI.Button(new Rect(40, 300, 200, 20), "Play Credits"))
            {
                SceneManager.LoadScene("Ending");
            }
            if (GUI.Button(new Rect(40, 330, 200, 20), "Close this menu"))
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
