using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.name);
    if (this.tag == other.tag)
      Debug.Log("병합시도");
    else
      Debug.Log("몰?루");
  }
  private void OnCollisionEnter(Collision collision)
  {
    Debug.Log(collision.gameObject.name);
    if (this.tag == collision.gameObject.tag)
      Debug.Log("병합시도");
    else
      Debug.Log("몰?루");
  }
}
