using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

	Vector3 prePos;

    private void OnMouseDown()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 20;
        prePos = Camera.main.ScreenToWorldPoint(mouse);
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 20;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 offset = newPos - prePos;
        this.transform.position += offset;
        prePos = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
