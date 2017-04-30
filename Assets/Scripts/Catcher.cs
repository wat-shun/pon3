using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Catcher : MonoBehaviour
{
  private Rigidbody2D _rigidbody2D;
  public float speed = 1.0f;
  public GameObject CatchParticle;

  public void Start()
  {
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  public void Update()
  {
    Vector3 nowPos = gameObject.transform.position;
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 a = new Vector3(mousePos.x - nowPos.x, 0, 0);
    _rigidbody2D.velocity = a.normalized * Mathf.Log(a.magnitude) * speed;
  }

  public void Catch(int point)
  {
    GameObject par = Instantiate(CatchParticle, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
//    var mainModule = par.GetComponent<ParticleSystem>().main;
//    mainModule.duration = point/10;
  }
}
