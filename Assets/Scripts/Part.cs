using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public string name;
    public GameObject gameObject;
    public Vector3 vector;
    public Color color;

    public Part(string newName, string axis)
    {
        name = newName;
        gameObject = GameObject.Find(name);
        color = gameObject.GetComponent<Renderer>().material.color;

        if (axis == "pitch")
        {
            vector = new Vector3(0, 0, 1);
        }
        else if (axis == "yaw")
        {
            vector = new Vector3(0, 1, 0);
        }
        else if (axis == "roll")
        {
            vector = new Vector3(1, 0, 0);
        }
    }

    public void removeHighlight()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    public void highlight()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
