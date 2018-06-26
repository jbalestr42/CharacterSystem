using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlacement : MonoBehaviour {

    public bool IsFree = true;

    public void Select() {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
        IsFree = false;
    }

    public void UnSelect() {
        IsFree = true;
    }

    public void Highlight() {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void HighlightOccupied() {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void UnHighlight() {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
