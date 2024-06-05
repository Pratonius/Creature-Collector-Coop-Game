using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class OrthObjectResize : MonoBehaviour
{
    private float height;
    private Vector3 objectSize;

    // Start is called before the first frame update
    void Start()
    {
        objectSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        height = Camera.main.orthographicSize * 2;
        float aspectRatio = height * Screen.width / Screen.height;
        gameObject.transform.localScale = Vector3.one + objectSize * aspectRatio /19f;
    }
}
