using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace HAM
{
  public class DragAndMove : MonoBehaviour
  {
    private GameObject objectHitPostion;
    private RaycastHit hitRay, hitLayerMask;

    Transform standardPosi;
    private void OnMouseUp()
    {  
      this.transform.parent = null;
      standardPosi = null;
      Destroy(objectHitPostion);
    }

    private void OnMouseDown()
    {
      //클릭시 오브젝트 위치 변동없게
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out hitRay))
      {
        objectHitPostion = new GameObject("HitPosition");
        objectHitPostion.transform.position = hitRay.point;
        this.transform.SetParent(objectHitPostion.transform);
        SaveExistingLocation(); //원래 있었던 위치 보관
      }
    }

    private void OnMouseDrag()
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

      int layerMask = 1 << LayerMask.NameToLayer("Stage");
      if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
      {
        float H = Camera.main.transform.position.y;
        float h = objectHitPostion.transform.position.y;

        Vector3 newPos
          = (hitLayerMask.point * (H - h) + Camera.main.transform.position * h) / H;

        objectHitPostion.transform.position = newPos;
      }
    }    

    //오브젝트가 클릭되면 원래 위치를 보관
    //병합이 안되었을때 본인 자리로 다시 돌아가야 하기 때문
    private void SaveExistingLocation()
    {
      for (int i = 0; i < WarriorManager.Instance.warriorsArr.Length; i++)
      {
        if (WarriorManager.Instance.warriorsArr[i].obj != null)
        {
          if (WarriorManager.Instance.warriorsArr[i].obj == hitRay.collider.gameObject)
          {
            standardPosi = WarriorManager.Instance.warriorsArr[i].obj.transform;
            break;
          }
        }
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if (this.tag == other.tag)
        Debug.Log("병합 시도");
      else
        Debug.Log("몰?루");
    }   

  }
}