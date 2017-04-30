using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Ball : MonoBehaviour
{
  private GameManager _gameManager;
  public int 基本ポイント = 1;
  [Range(0, 3)] public int バウンド回数;

  public int Score
  {
    get { return 基本ポイント * (バウンド回数 + 1); }
  }

  public void Start()
  {
    _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
  }

  public void Update()
  {
    // 画面外に出たら破壊
    if (transform.position.y < -10) Destroy(gameObject);
  }

  void OnCollisionEnter2D(Collision2D coll)
  {
    string layername = LayerMask.LayerToName(coll.collider.gameObject.layer);

    switch (layername)
    {
      case "Catcher(inside)":
        _gameManager.GetScore(Score);
        // TODO:獲得音追加
        // TODO:獲得パーティクル追加
        Destroy(gameObject);
        break;

      case "Catcher(outside)":
      case "Floor":
        バウンド回数++;
        // TODO:跳躍エフェクト追加
        // TODO:跳躍音追加
        // TODO:損壊パーティクル追加
        switch (バウンド回数)
        {
          case 1:
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1, ForceMode2D.Impulse);
            break;
          case 2:
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1, ForceMode2D.Impulse);
            break;
          case 3:
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 8, ForceMode2D.Impulse);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            break;
          case 4:
            Destroy(gameObject);
            break;
        }
        break;
    }
  }
}
