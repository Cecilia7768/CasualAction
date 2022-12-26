using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class BulletManager : MonoBehaviour
{
  public float speed = 3f;
  public abstract void Launch(); //�߻������� ����, �ӵ� ��

  public void DestroyObj(GameObject me, GameObject monster)
  {  
      Destroy(me.gameObject);
      Destroy(monster.gameObject); 
  }
}
