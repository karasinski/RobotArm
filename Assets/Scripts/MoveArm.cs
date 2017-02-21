using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArm : MonoBehaviour
{
    public float moveScale;

    private List<Part> parts = new List<Part>();
    private Part part;
    private int partIndex;

    // Use this for initialization
    void Start()
    {
        parts.Add(new Part("armA:SR-joint", "roll"));
        parts.Add(new Part("armA:SY-joint", "yaw"));
        parts.Add(new Part("armA:SP-joint", "pitch"));
        parts.Add(new Part("armA:EP-joint", "pitch"));
        parts.Add(new Part("armA:WP-joint", "pitch"));
        parts.Add(new Part("armA:WY-joint", "yaw"));
        parts.Add(new Part("armA:WR-joint", "roll"));

        partIndex = 0;
        setPart();
    }

    void setPart()
    {
        part = parts[partIndex];
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        part.gameObject.transform.Rotate(part.vector, moveScale * input * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.UpArrow) && partIndex < parts.Count)
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
