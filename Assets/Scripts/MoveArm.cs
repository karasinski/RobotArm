using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArm : MonoBehaviour
{
    public float moveScale;

    private List<Part> parts = new List<Part>();
    private Part part;
    private int partIndex;

    void Start()
    {
        parts.Add(new Part("Canadarm2_002", "yaw"));
        parts.Add(new Part("Canadarm2_003", "roll"));
        parts.Add(new Part("Canadarm2_004", "pitch"));
        parts.Add(new Part("Canadarm2_006", "pitch"));
        parts.Add(new Part("Canadarm2_007", "pitch"));
        parts.Add(new Part("Canadarm2_008", "yaw"));
        parts.Add(new Part("Canadarm2_009", "roll"));

        partIndex = 0;
        setPart();
    }

    void setPart()
    {
        try
        {
            part.removeHighlight();
        } catch { }

        part = parts[partIndex];
        part.highlight();
    }

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
    }
}
