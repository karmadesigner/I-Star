using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
