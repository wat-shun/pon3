using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPoint : MonoBehaviour
{
  private GameManager _gameManager;
  public GameObject BallPrefab;
  public Color GizmoColor;
  public float ShootSpeed;

  public float[] Schedule;
  private int now = 0;

  private Vector3 _basePos;
  private Vector3 _baseRot;

  void Start()
  {
    _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    _basePos = transform.position;
    _baseRot = transform.rotation.eulerAngles;
  }

  void Update()
  {
    transform.position = _basePos + new Vector3(0, Mathf.Sin(_gameManager.残り時間 * 5), 0);

    transform.rotation = Quaternion.Euler(0,0,_baseRot.z + Mathf.Sin(_gameManager.残り時間) * 15);

    if (Schedule.Length > now)
    {
      if (_gameManager.残り時間 <= Schedule[now])
      {
        Vector3 vec = transform.rotation * Vector3.up * ShootSpeed;

        GameObject newBall = Instantiate(BallPrefab, transform.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody2D>().AddForce(vec, ForceMode2D.Impulse);

        now++;
      }
    }

  }

  void OnDrawGizmos ()
  {
    Gizmos.color = GizmoColor;
    Gizmos.DrawSphere(transform.position, 0.3f);
    Gizmos.DrawLine(transform.position, transform.position + transform.rotation  * Vector3.up * 2 );
  }
}
