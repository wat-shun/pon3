using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public float 残り時間 = 60.0f;
  public int 得点 = 0;

  public GameObject Catcher;
  public Text 残り時間ボード;
  public Text 得点ボード;
  public GameObject ゲームオーバー;
  public Text ゲームオーバースコアボード;

  // Use this for initialization
  void Start()
  {
    Time.timeScale = 1.0f;
  }

  // Update is called once per frame
  void Update()
  {
    残り時間 -= Time.deltaTime;
    if (残り時間 < 0)
    {
      残り時間 = 0;
      Gameover();
    }

    残り時間ボード.text = 残り時間.ToString("F1") + "秒";
  }

  public void GetScore(int score)
  {
    得点 += score;
    得点ボード.text = 得点 + "点";
    Catcher.GetComponent<Catcher>().Catch(score);
  }

  private void Gameover()
  {
    Time.timeScale = 0.0f;
    ゲームオーバー.SetActive(true);
    ゲームオーバースコアボード.text = "Score : " + 得点;
  }
}
