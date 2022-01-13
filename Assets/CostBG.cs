using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostBG : MonoBehaviour
{
    public GameObject cost;
    // Start is called before the first frame update
    public void UpdateText(string text)
    {
        cost.GetComponent<Text>().text = text;
    }
}
