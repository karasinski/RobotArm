using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArm : MonoBehaviour
{
    private GameObject part;
    public float moveScale;

    private string[] parts = new string[] { "armA:SR-joint", "armA:SY-joint", "armA:SP-joint", "armA:EP-joint", "armA:WP-joint", "armA:WY-joint", "armA:WR-joint" };
    private int partIndex;

    // Use this for initialization
    void Start()
    {
        partIndex = 0;
        setPart();
    }

    void setPart()
    {
        part = GameObject.Find(parts[partIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        part.transform.Rotate(moveScale * input * Time.deltaTime, 0, 0);

        if (Input.GetKeyUp(KeyCode.UpArrow) && partIndex < parts.Length)
        {
            partIndex++;
            setPart();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && partIndex > 0)
        {
            partIndex--;
            setPart();
        }
        print(partIndex);
    }
}
