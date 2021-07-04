using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{

    public GameObject sourceValue;
    private void Start()
    {
        SetText(sourceValue.GetComponent<Slider>().value);
    }
    public void SetText(float val) {
        gameObject.GetComponent<Text>().text = $"{val:f1}";
    }
}
