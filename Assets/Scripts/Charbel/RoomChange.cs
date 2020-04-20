using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomSetting {
    public string name;
    public GameObject originalRoom;
    public GameObject swapRoom;
}

public class RoomChange : MonoBehaviour
{
    Transform player;
    public List<RoomSetting> roomSettings;


    public GameObject LivingRoom;
    public GameObject LivingRoomSwap;

    public GameObject Bathroom;
    public GameObject BathroomSwap;


    public GameObject Basement;
    public GameObject BasementSwap;


    public GameObject SmallBedroom;
    public GameObject SmallBedroomSwap;

    public GameObject Dinningroom;
    public GameObject DinningroomSwap;

    public GameObject Mainbedroom;
    public GameObject MainbedroomSwap;

    public GameObject Demon;
    public GameObject DemonSwap;



    BoxCollider collider;


    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
        player = FindObjectOfType<FirstPersonAIO>().transform;
    }

    private void Update()
    {
        Vector3 posDiff = player.position - transform.position;
        float dotPos = Vector3.Dot(transform.forward, posDiff);
        if (dotPos < -2f)
        {
            collider.enabled = true;

        }

        else if (dotPos > 1)
        {
            collider.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!GameEventManager.allRoom.Contains(this))
            {
                GameEventManager.allRoom.Add(this);
            }

            for (int i = 0; i < roomSettings.Count; i++)
            {
                roomSettings[i].originalRoom.SetActive(roomSettings[i].swapRoom.activeInHierarchy);
                roomSettings[i].swapRoom.SetActive(!roomSettings[i].originalRoom.activeInHierarchy);
            }


            Basement.SetActive(BasementSwap.activeInHierarchy);
            BasementSwap.SetActive(!Basement.activeInHierarchy);

            SmallBedroom.SetActive(SmallBedroomSwap.activeInHierarchy);
            SmallBedroomSwap.SetActive(!SmallBedroom.activeInHierarchy);

            Dinningroom.SetActive(DinningroomSwap.activeInHierarchy);
            DinningroomSwap.SetActive(!Dinningroom.activeInHierarchy);

            Mainbedroom.SetActive(MainbedroomSwap.activeInHierarchy);
            MainbedroomSwap.SetActive(!Mainbedroom.activeInHierarchy);


            Demon.SetActive(DemonSwap.activeInHierarchy);
            DemonSwap.SetActive(!Demon.activeInHierarchy);
        }

        if (gameObject.name != "LilyRoomTrigger")
        {
            if (GameEventObserver.i.IsDialougeCompleted())
            {
                GameEventObserver.i.isRoomChange = true;
            }
        }
        else
        {
            GameEventObserver.i.isEnterLilyRoom = true;
        }
    }
}

  
