using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public GameObject restartPanel;
    public TextMeshProUGUI txtpallet;
    public TextMeshProUGUI txtscore1;
    public TextMeshProUGUI txtscore2;
    public TextMeshProUGUI txtscore3;
    public TextMeshProUGUI txttotalscore;
    private int score1;
    private int score2;
    private int score3;
    private int totalscore;
    public int gerekliscore;
    public CreatesSpawnandTransport createsSpawnandTransport;
    public PlayerWASD playerWASD;
    void Update()
    {
        txtscore1.text = score1.ToString();
        txtscore2.text = score2.ToString();
        txtscore3.text = score3.ToString();
        txttotalscore.text = totalscore.ToString();
        txtpallet.text = createsSpawnandTransport.randomboxnumber.ToString();
        totalscore = score1 + score2 + score3;
        if (totalscore == gerekliscore)
        {
            SceneManager.LoadScene("LevelSelect");
        }
        if(playerWASD.gameoverscreen == true)
        {
            GameOverScreen();
        }
    }
    public void PuanEkle()
    {
        if (createsSpawnandTransport.birakmaAlani1 == true)
        {
            score1++;
        }
        if (createsSpawnandTransport.birakmaAlani2 == true)
        {
            score2 = score2 +1;
        }
        if (createsSpawnandTransport.birakmaAlani3 == true)
        {
            score3 = score3 +1;
        }  
    }    
    private void GameOverScreen()
    {
        restartPanel.SetActive(true);
    }
}
