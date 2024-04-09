using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveData : MonoBehaviour
{
    public GameObject player;

  public void PlayerPosSave()
    {
        PlayerPrefs.SetInt("LoadSaved", 1);
    }
}
