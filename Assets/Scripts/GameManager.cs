using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text _text;
    public float count;
    public bool Stopcount;
    public int Totalcoin;
    public int CoinCollected;
    public GameObject CoinHolder;
    private int nextSceneToload;
    public Text StatusText;
    private float TextShowtime = 3f;
    public int NextlevelId;
    public int CurrentlevelId;
    int WinIndex = 4;
    int LoseIndex = 3;
    void Start()
    {
        StatusText.enabled = false;
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);

        Totalcoin = CoinHolder.transform.childCount;
        _text.text = "Timer :" + count;
       

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        if(Totalcoin == CoinCollected)
        {
            Debug.Log("PlayerWin");
        }
        if (CoinHolder.transform.childCount == 0)
        {
            StatusText.text = "YOU WIN";
            StatusText.enabled = true;
            if (TextShowtime <= 0)
            SceneManager.LoadScene(WinIndex);
        }
        

        if (count <= 0)
        {
            StatusText.text = "YOU LOSE";
            StatusText.enabled = true;
            TextShowtime -= Time.deltaTime;
            if (TextShowtime <= 0)
                SceneManager.LoadScene(LoseIndex);
        }
        void Timer()
        {
            if (Stopcount == false)
            {
                count -= 1 * Time.deltaTime;
            }
            if (count < 0)
            {
                Stopcount = true;
            }
            _text.text = "Timer :" + (int)count;
        }


    }
}
