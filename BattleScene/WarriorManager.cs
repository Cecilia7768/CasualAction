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
      //public int price; //가격
      //public int amount; //한번 구매시 생성되는 갯수
      //public int currAmount; //현재 생성되어있는 갯수
    }

    [SerializeField] private Transform[] CreatePosi = new Transform[36];

    [Header("현재 배치되어있는 전사오브젝트 정보")]
    public Warriors[] warriorsArr = new Warriors[36];

    #region 전사 오브젝트들

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
    /// 오브젝트 타입별 정보 셋팅
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
