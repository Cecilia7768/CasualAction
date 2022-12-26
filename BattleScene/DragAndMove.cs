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
      //Ŭ���� ������Ʈ ��ġ ��������
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(ray, out hitRay))
      {
        objectHitPostion = new GameObject("HitPosition");
        objectHitPostion.transform.position = hitRay.point;
        this.transform.SetParent(objectHitPostion.transform);
        SaveExistingLocation(); //���� �־��� ��ġ ����
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

    //������Ʈ�� Ŭ���Ǹ� ���� ��ġ�� ����
    //������ �ȵǾ����� ���� �ڸ��� �ٽ� ���ư��� �ϱ� ����
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
        Debug.Log("���� �õ�");
      else
        Debug.Log("��?��");
    }   

  }
}