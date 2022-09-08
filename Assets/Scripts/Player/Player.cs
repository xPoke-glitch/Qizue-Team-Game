using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xPoke.CustomLog;

public class Player : MonoBehaviour
{
    private bool _isGameOverDeclared = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (transform.position.y < -6.0f && !_isGameOverDeclared)
        {
            CustomLog.Log(CustomLog.CustomLogType.GAMEPLAY, "GameOver for falling");
            GameController.Instance.GameOver();
            _isGameOverDeclared = true;
            Destroy(this.gameObject,1.0f);
        }
    }
}
