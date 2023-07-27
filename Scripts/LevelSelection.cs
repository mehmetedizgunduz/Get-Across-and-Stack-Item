using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{ 
    public void Level1Select()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Level2Select()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
}
