using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cameras = new GameObject[3];

    void Update()
    {
        if (Input.GetKeyDown("1") && cameras[0] != null)
        {
            switchCameras(0);
        }
        else if (Input.GetKeyDown("2") && cameras[1] != null)
        {
            switchCameras(1);
        }
        else if (Input.GetKeyDown("3") && cameras[2] != null)
        {
            switchCameras(2);
        }
        else if (Input.GetKeyDown("4"))
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(true);
            cameras[2].SetActive(true);

            cameras[0].GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
            cameras[1].GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
            cameras[2].GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }

    private void switchCameras(int keyNum)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            // have the camera fill the whole view
            cameras[i].GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);

            if (cameras[i] != null && keyNum != i)
            {
                // turn camera off
                cameras[i].SetActive(false);
            }
            else
            {
                // turn camera on
                cameras[i].SetActive(true);
            }
        }
    }
}