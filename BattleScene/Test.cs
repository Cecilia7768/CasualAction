using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.name);
    if (this.tag == other.tag)
      Debug.Log("���սõ�");
    else
      Debug.Log("��?��");
  }
  private void OnCollisionEnter(Collision collision)
  {
    Debug.Log(collision.gameObject.name);
    if (this.tag == collision.gameObject.tag)
      Debug.Log("���սõ�");
    else
      Debug.Log("��?��");
  }
}
