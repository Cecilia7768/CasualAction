using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class BulletManager : MonoBehaviour
{
  public float speed = 3f;
  public abstract void Launch(); //발사했을때 방향, 속도 등

  public void DestroyObj(GameObject me, GameObject monster)
  {  
      Destroy(me.gameObject);
      Destroy(monster.gameObject); 
  }
}
