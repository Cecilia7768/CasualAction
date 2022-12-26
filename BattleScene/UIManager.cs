using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HAM
{
  public class UIManager : MonoBehaviour
  {
    [SerializeField] private TMP_Text goldTxt;

    private void Start()
    {
      init();
    }

    private void init()
    {
      goldTxt.text = Manager.Instance.gold.ToString();
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void OnClickBuy()
    {

    }
  }
}