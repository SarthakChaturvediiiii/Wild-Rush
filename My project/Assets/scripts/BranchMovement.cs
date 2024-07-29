using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchMovement : MonoBehaviour
{
    public float swingSpeed = 2f;
    public float swingAngle = 20f;

    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(Swing());
    }

    private IEnumerator Swing()
    {
        while (true)
        {
           // float angleX = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
            float angleY = Mathf.Cos(Time.time * swingSpeed) * swingAngle;
            rectTransform.rotation = Quaternion.Euler(0, angleY, 0);
            yield return null;
        }
    }
    //public void 
}
