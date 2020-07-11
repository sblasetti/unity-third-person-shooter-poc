using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    InputController inputController;

    // Start is called before the first frame update
    void Start()
    {
        inputController = GameManager.GetInstance().GetInputController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
