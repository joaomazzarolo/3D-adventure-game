using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public List<GameObject> endGameObjects;
    private bool endGame = false;
    public int currentLevel = 1;
    private void Awake()
    {
        endGameObjects.ForEach(i => i.SetActive(false));
    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();

        if (!endGame && p != null)
        {
            ShowEndGame();
        }
    }

    private void ShowEndGame()
    {
        endGame = true;
        endGameObjects.ForEach(i => i.SetActive(true));

        foreach(var i in endGameObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            SaveManager.Instance.SaveLastLevel(currentLevel);
        }

    }
}
