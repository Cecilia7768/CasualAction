using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HAM
{
  public class WarriorManager : MonoSingleton<WarriorManager>
  {
    public struct Warriors
    {
      public WarriorType Type;
      public GameObject obj;
      //public int price; //����
      //public int amount; //�ѹ� ���Ž� �����Ǵ� ����
      //public int currAmount; //���� �����Ǿ��ִ� ����
    }

    [SerializeField] private Transform[] CreatePosi = new Transform[36];

    [Header("���� ��ġ�Ǿ��ִ� ���������Ʈ ����")]
    public Warriors[] warriorsArr = new Warriors[36];

    #region ���� ������Ʈ��

    [SerializeField] private Transform warriorsParent;
    [SerializeField] private GameObject[] warriorKindArr;

   
    #endregion
    private void Awake()
    {
      Init();
      var ranPosi = Random.Range(0, CreatePosi.Length);
      var ranWarriorType = Random.Range(0, warriorKindArr.Length);
      for (int i = 0; i < 2; i++)
      {
        if (warriorsArr[ranPosi].Type == WarriorType.none)
          ClassificationOfTypes(ranPosi, ranWarriorType);
        else
        {
          ranPosi = Random.Range(0, CreatePosi.Length);
          i -= 1;
        }
      }
    }

    private void Init()
    {
      for(int i = 0; i < warriorsArr.Length; i++)    
        warriorsArr[i].Type = WarriorType.none;  
    }

    /// <summary>
    /// ������Ʈ Ÿ�Ժ� ���� ����
    /// </summary>
    private void ClassificationOfTypes(int ranPosi, int ranWarriorType)
    {
      //var tmp = warriorType switch
      //{
      //  (int)WarriorType.Santa => warriorsArr[randomlistPosi].Type = WarriorType.Santa
      //};
      var obj = Instantiate(warriorKindArr[ranWarriorType], warriorsParent);
      obj.transform.position = CreatePosi[ranPosi].position;
      warriorsArr[ranPosi].obj = obj;
      switch (ranWarriorType)
      {
        case (int)WarriorType.Santa:
          warriorsArr[ranPosi].Type = WarriorType.Santa;
          break;
      }
    }

  }
}
