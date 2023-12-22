using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{

    [SerializeField]
    private Edge otherEdge;

    public void Switch()
    {
        otherEdge.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

}
