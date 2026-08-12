using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointBase : MonoBehaviour
{
    public int key = 01;
    public MeshRenderer meshRenderer;
    private string checkPointKey = "CheckpointKey";
    private bool checkPointActivated = false;
    public Text checkPointMessage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            CheckCheckPoint();
        }
    }

    private void CheckCheckPoint()
    {
        SaveCheckPoint();
        TurnItOn();
    }
    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        Invoke(nameof(ActivateMessage), .1f);
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
        Invoke(nameof(DeactivateMessage), 4f);
    }
    private void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.black);
    }

    private void SaveCheckPoint()
    {
        //if(PlayerPrefs.GetInt(checkPointKey, 0) > key)
        //    PlayerPrefs.SetInt(checkPointKey, key);

        CheckPointManager.Instance.SaveCheckPoint(key);

        checkPointActivated = true;
    }

    private void ActivateMessage()
    {
        checkPointMessage.gameObject.SetActive(true);
    }
    private void DeactivateMessage()
    {
        checkPointMessage.gameObject.SetActive(false);
    }
}
