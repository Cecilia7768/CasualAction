using HAM;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HAM
{
  class SnowBullet : BulletManager
  {

    [Range(0, 2)]
    public float bulletSpeed = .13f;
    private void Start()
    {
      Launch();
      StartCoroutine(SetFirstEnemy());
    }
    IEnumerator SetFirstEnemy()
    {
      while (true)
      {
        yield return Coroutine.wait01;
        if (!EnemyManager.Instance.resetFirstEnemy)
          transform.position = Vector3.MoveTowards(this.transform.position, EnemyManager.firstEnemy.transform.position, bulletSpeed);
      }
    }
    public override void Launch()
      => this.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);


    public void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag.Equals("Monster") && other.gameObject == EnemyManager.firstEnemy)
      {
        EnemyManager.Instance.resetFirstEnemy = true;
        DestroyObj(this.gameObject, other.gameObject);
      }
    }
  }
}