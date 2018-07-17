//====================================================================
// Initialized :17.7.2018  12.00
// Last edited :
//====================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagButtonClick : MonoBehaviour {

    public Dropdown inventory;
    public GameObject blurredCanvas;
    bool isCanvasAvtive = false;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isCanvasAvtive)
            {
                blurredCanvas.SetActive(false);
                isCanvasAvtive = false;

            }
        }
    }


    public void inventoryIsClicked()
    {
        inventory.captionText.text = " ";
        inventory.Show();

        if (!isCanvasAvtive)
        {
            blurredCanvas.SetActive(true);
            isCanvasAvtive = true;
        }
    }

}
