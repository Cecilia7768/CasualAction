using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HAM
{
  public class EnemyManager : MonoSingleton<EnemyManager>
  {
    [SerializeField] private GameObject monster;
    [SerializeField] private int maxNum = 10; //���� �ִ� ��������. ���߿� ��ȹ������ ��������
    public Queue<GameObject> monsterList = new Queue<GameObject>();
    static public GameObject firstEnemy;

    //ù��° �� ����
    public bool resetFirstEnemy= false;
    private void Start()
    {
      StartCoroutine(CreateMonster());
      StartCoroutine(SetFirstEnemy());
      // init();
    }

    IEnumerator CreateMonster()
    {
      for (int i = 0; i < maxNum; i++)
      {
        var obj = Instantiate(monster, this.transform);
        if(i.Equals(0))
          firstEnemy = obj;
        monsterList.Enqueue(obj);
        yield return Coroutine.wait1;
      }    
    }
    IEnumerator SetFirstEnemy()
    {
      while(true)
      {
        yield return Coroutine.wait001;
        if (resetFirstEnemy)
        {
          firstEnemy = null;
          monsterList.Dequeue();
          firstEnemy = monsterList.Peek();
          yield return Coroutine.wait001;

          resetFirstEnemy = false;
        }
      }
    }
  }
}