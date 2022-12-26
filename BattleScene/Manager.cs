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
    public Transform[] movePosi; //�̵��ؾ��ϴ� ������
    public int gold = 100; //���� ù���۽� �־����� ���. ���߿� �ٲ������.

    public EnumDictionary<MonsterPosi, int> monsterPosiDic = new EnumDictionary<MonsterPosi, int>();
    private void Awake()
    {
      SetEnumData();
    }
    /// <summary>
    /// Enum Data �ڽ̾��� �ޱ����� ��ųʸ� ����. 
    /// ���߿� �� ȿ������ ������ִٸ�(����� �Ҽ��ְԵǸ�) �����Ұ�
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