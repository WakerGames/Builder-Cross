using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowToxinEdge : MonoBehaviour
{

    public GameObject edgeImg;
    public GameObject img;

    void Update()
    {
        if (img.GetComponent<Image>().fillAmount < .98f)
        {
            edgeImg.GetComponent<RectTransform>().localPosition = new Vector3(-50, img.GetComponent<Image>().fillAmount * 1268 - 610, 0);
        }
        else
        {
            edgeImg.SetActive(false);
        }

        
    }
}
