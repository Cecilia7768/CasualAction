using UnityEngine;


namespace HAM
{
  public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
  {
    private static T instance = null;
    public static T Instance
    {
      get
      {
        if (instance == null)
        {
          instance = FindObjectOfType(typeof(T)) as T;
          if (instance == null)        
            instance = new GameObject(typeof(T).ToString(), typeof(T)).AddComponent<T>();     
        }
        return instance;
      }
    }
  }

  public class Manager : MonoSingleton<Manager>
  {
    public Transform[] movePosi; //이동해야하는 포지션
    public int gold = 100; //게임 첫시작시 주어지는 골드. 나중에 바뀔수있음.

    public EnumDictionary<MonsterPosi, int> monsterPosiDic = new EnumDictionary<MonsterPosi, int>();
    private void Awake()
    {
      SetEnumData();
    }
    /// <summary>
    /// Enum Data 박싱없이 받기위해 딕셔너리 세팅. 
    /// 나중에 더 효율적인 방법이있다면(제대로 할수있게되면) 수정할것
    /// </summary>
    private void SetEnumData()
    {
      monsterPosiDic.Add(MonsterPosi.None, -1);
      monsterPosiDic.Add(MonsterPosi.Start, 0);
      monsterPosiDic.Add(MonsterPosi.Final, 3);
      //monsterPosiDic.Add(MonsterPosi.Max, 16);
    }

  }
}