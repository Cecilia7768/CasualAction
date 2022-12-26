using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace HAM
{
  public class Monster : MonoBehaviour
  {
    Manager m;

    //���� �̵���ǥ ��ġ ����
    private int goalPosiNum = 1;
    private Vector3 goalPosi;

    //������Ʈ
    NavMeshAgent nav;

    //���� ����üũ�� ����
    bool changeGoal = false;
    void Start()
    {
      m = Manager.Instance;
      nav = GetComponent<NavMeshAgent>();
      StartCoroutine(Move());
      StartCoroutine(SetNextPosi());
    }

    #region **Enum Data �޾ƿ���

    //��ųʸ����� key�� ���� �޾ƿ�
    private int GetEnumValue(MonsterPosi posi)
    {
      m.monsterPosiDic.TryGetValue(posi, out int value);
      return value;
    }
    #endregion


    IEnumerator Move()
    {
      goalPosi = m.movePosi[goalPosiNum].position;
      while (true)
      {    
        nav.destination = goalPosi; 
        if (changeGoal)
        {
          goalPosiNum++;
          if (goalPosiNum > GetEnumValue(MonsterPosi.Final))   
            goalPosiNum = GetEnumValue(MonsterPosi.Start);
          goalPosi = m.movePosi[goalPosiNum].position;
          changeGoal = !changeGoal;
        }

        ////���� ù��° ���Ͷ��
        //if (this.gameObject == EnemyManager.Instance.gameObject.transform.GetChild(0))
        //  EnemyManager.firstEnemy.transform.position = this.gameObject.transform.position;
        yield return new WaitForSeconds(.1f);
      }
    }

    IEnumerator SetNextPosi()
    {
      while (true)
      {
        yield return new WaitForSeconds(.1f);
        if (Vector3.Distance(goalPosi, this.transform.position) < .5f) //�������� �ٿ�����
          changeGoal = true;
        else
          changeGoal = false;
      }
    }
  
  }
}