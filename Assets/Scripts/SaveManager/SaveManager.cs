using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Ebac.Singleton;
using System;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private SaveSetup setup;
    private string path = Application.streamingAssetsPath + "/save.txt";
    public HealthBase healthBase;
    public int lastLevel;
    public Action<SaveSetup> FileLoaded;

    private void Start()
    {
        Invoke(nameof(Load), .5f);
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public SaveSetup Setup
    {
        get { return setup; }
    }

    private void CreateNewSave()
    {
        setup = new SaveSetup();
        setup.lastLevel = 0;
        setup.playerName = "PlayerName";
        setup.coins = 0;
        setup.health = 0;
        setup.lastPosition = new Vector3(416,-7.62f,6.83f);
        setup.texture = null;
        setup.playerHealth = 100;
}
    public void SaveMenuButton()
    {
        if (File.Exists(path))
        {
            Save();
        }
        else
        {
            CreateNewSave();
            Save();
        }
    }

    #region SAVE
    [NaughtyAttributes.Button]
    public void Save()
    {
        string setupToJson = JsonUtility.ToJson(setup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }
    public void SaveItems()
    {
        setup.coins = Items.ItemManager.Instance.GetItemByType(Items.ItemType.COIN).soInt.value;
        setup.health = Items.ItemManager.Instance.GetItemByType(Items.ItemType.LIFE_PACK).soInt.value;
        Save();
    }
    public void SaveHealth(float health)
    {
        setup.playerHealth = health;
        Save();
    }
    public void SaveName(string name)
    {
        setup.playerName = name;
        Save();
    }
    public void SaveLastCheckpoint(Vector3 pos)
    {
        setup.lastPosition = pos;
        Save();
    }
    public Vector3 GetLastCheckpoint()
    {
        var pos = setup.lastPosition;
        return pos;
    }
    public float GetPlayerHealthFromFile()
    {
        var health = setup.playerHealth;
        return health;
    }
    public void SaveLastLevel(int level)
    {
        setup.lastLevel = level;
        SaveItems();
        Save();
    }
    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }
    #endregion

    private void SaveFile(string json)
    {
        Debug.Log(path);
        File.WriteAllText(path, json);
    }
    [NaughtyAttributes.Button]
    private void Load()
    {
        string fileLoaded = "";

        if (File.Exists(path))
        {
            fileLoaded = File.ReadAllText(path);

            setup = JsonUtility.FromJson<SaveSetup>(fileLoaded);
            lastLevel = setup.lastLevel;
        }
        else
        {
            CreateNewSave();
            Save();
        }
        FileLoaded.Invoke(setup);
    }
}
[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;
    public float coins;
    public float health;
    public Vector3 lastPosition;
    public Texture texture;
    public float playerHealth;
}
