using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HAM
{
  public class EnumManager<TEnumkey, Tvalue>
  {
    public readonly Dictionary<TEnumkey, int> enumDic;
    void Start()
    {
     
    }

    //����
    public EnumManager()
    {
      enumDic = new Dictionary<TEnumkey, int>();
    }


  }
}