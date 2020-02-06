using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextureSetup : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;

    public Material camera1Mat;
    public Material camera2Mat;
    public Material camera3Mat;
    public Material camera4Mat;


    // When game starts remove current camera textures and set new textures with the dimensions of the players screen
    void Start()
    {
        if (camera1.targetTexture != null)
        {
            camera1.targetTexture.Release();
        }
        camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera1Mat.mainTexture = camera1.targetTexture;

        if (camera2.targetTexture != null)
        {
            camera2.targetTexture.Release();
        }
        camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera2Mat.mainTexture = camera2.targetTexture;

        if (camera3.targetTexture != null)
        {
            camera3.targetTexture.Release();
        }
        camera3.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera3Mat.mainTexture = camera3.targetTexture;

        if (camera4.targetTexture != null)
        {
            camera4.targetTexture.Release();
        }
        camera4.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera4Mat.mainTexture = camera4.targetTexture;

    }

}
