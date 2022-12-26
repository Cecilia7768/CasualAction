using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HAM
{
  public class Santa : MonoBehaviour
  {
    [SerializeField] private GameObject snow;
    //[SerializeField] private float speed= 50f; //발사체 속도
    void Awake()
    {
      StartCoroutine(Rotate());
    }
    IEnumerator Rotate() //첫번째 몬스터 방향으로 회전
    {
      while (true)
      {     
        if (EnemyManager.firstEnemy)
        {
          Vector3 relativePos = EnemyManager.firstEnemy.transform.position - this.transform.position;
          Quaternion rot = Quaternion.LookRotation(relativePos, Vector3.up);
          this.transform.rotation = rot;          
        }
        yield return Coroutine.wait001;
      }
    }

    public void CreateSnow()
    {
      if(!EnemyManager.Instance.resetFirstEnemy)
        Instantiate(snow, transform.position + new Vector3(0,.4f,0), transform.rotation);   
    }

  }
}