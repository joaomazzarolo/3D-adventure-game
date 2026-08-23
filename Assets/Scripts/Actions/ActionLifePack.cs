using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
using UnityEngine.UI;

public class ActionLifePack : MonoBehaviour
{
    public KeyCode keycode = KeyCode.L;
    public SOInt soInt;
    public Text guideMessage;

    private void Start()
    {
        soInt = ItemManager.Instance.GetItemByType(ItemType.LIFE_PACK).soInt;
    }

    private void RecoverLife()
    {
        if(soInt.value > 0)
        {
            ItemManager.Instance.RemoveByType(ItemType.LIFE_PACK);
            Player.Instance.healthBase.ResetLife();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            RecoverLife();
        }
        if(soInt.value > 0)
        {
            guideMessage.gameObject.SetActive(true);
        }
        else
        {
            guideMessage.gameObject.SetActive(false);
        }
    }
}
