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

    //다음 이동목표 위치 관련
    private int goalPosiNum = 1;
    private Vector3 goalPosi;

    //컴포넌트
    NavMeshAgent nav;

    //현재 상태체크용 변수
    bool changeGoal = false;
    void Start()
    {
      m = Manager.Instance;
      nav = GetComponent<NavMeshAgent>();
      StartCoroutine(Move());
      StartCoroutine(SetNextPosi());
    }

    #region **Enum Data 받아오기

    //딕셔너리에서 key로 값을 받아옴
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

        ////내가 첫번째 몬스터라면
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
        if (Vector3.Distance(goalPosi, this.transform.position) < .5f) //목적지에 다왔으면
          changeGoal = true;
        else
          changeGoal = false;
      }
    }
  
  }
}