using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOpenClose : MonoBehaviour
{
    public void onClickClose(GameObject popup)
    {
        popup.SetActive(false);

    }
    public void onClickOpen(GameObject popup)
    {
        popup.SetActive(true);
    }
}
