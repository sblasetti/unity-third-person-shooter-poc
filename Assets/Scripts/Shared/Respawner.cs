using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public void Despawn(GameObject gobj, float inSeconds)
    {
        gobj.SetActive(false);
        GameManager.GetInstance().GetTimer().Add(inSeconds, () => { gobj.SetActive(true); });
    }
}
