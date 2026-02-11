using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Cameras
{
  public enum PivotAlign
  {
    Center,
    LeftTop,
    RightTop,
    RightBottom,
    LeftBottom,
  }
  public class PlayerCamera : MonoBehaviour
  {
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 maxMouseLookOffset;
    [SerializeField] private Vector2 moveBox;
    [SerializeField] private PivotAlign pivotAlign;
    
    
    
    private void Update()
    {
      MoveToTarget();
    }

    private void MoveToTarget()
    {
      // var targetPos = _mainCamera.WorldToScreenPoint(target.position);
      
      var screenCenter = new Vector2(Screen.width/2, Screen.height/2);
      
      // Vector2 positive = new Vector2(screenCenter.x + moveBox.x, screenCenter.y + moveBox.y);
      // Vector2 negative = new Vector2(screenCenter.x - moveBox.x, screenCenter.y - moveBox.y);
      //
      // Vector2 positiveWorld = _mainCamera.ScreenToWorldPoint(positive);
      // Vector2 negativeWorld = _mainCamera.ScreenToWorldPoint(negative);
      
      var t = MoveMouseOffset();
      var tv = new Vector2(screenCenter.x + t.x, screenCenter.y + t.y);
      tv = _mainCamera.ScreenToWorldPoint(tv);
      var screenCenterWorld = _mainCamera.ScreenToWorldPoint(screenCenter);
      tv = new Vector2(tv.x - screenCenterWorld.x, tv.y - screenCenterWorld.y);
      transform.position = new Vector3(target.transform.position.x + tv.x,target.transform.position.y + tv.y,transform.position.z);
      
      // if (!(targetPos.x < negative.x || targetPos.x > positive.x || targetPos.y < negative.y || targetPos.y > positive.y))
      //   return;
      //
      // Vector2 vector = Vector2.zero;
      //
      // if (targetPos.x < negative.x)
      // {
      //   vector.x = target.position.x - negativeWorld.x;
      // }
      // else if (targetPos.x > positive.x)
      // {
      //   vector.x = target.position.x - positiveWorld.x;
      // }
      //
      // if (targetPos.y < negative.y)
      // {
      //   vector.y = target.position.y - negativeWorld.y;
      // }
      // else if (targetPos.y > positive.y)
      // {
      //   vector.y = target.position.y - positiveWorld.y;
      // }
      //
      // transform.position = new Vector3(transform.position.x + vector.x, transform.position.y + vector.y, transform.position.z);
    }

    private Vector2 MoveMouseOffset()
    {
      var mousePosition = Mouse.current.position.ReadValue();
      var screenCenter = new Vector2(Screen.width/2, Screen.height/2);

      mousePosition -= screenCenter;
      
      var direction = new Vector2(mousePosition.x / screenCenter.x, mousePosition.y / screenCenter.y);
      
      if (mousePosition.x > screenCenter.x)
      {
        direction.x *= -1;
      }
      if (mousePosition.y > screenCenter.y)
      {
        direction.y *= -1;
      }
      
      var offset = new Vector2(direction.x * maxMouseLookOffset.x, direction.y * maxMouseLookOffset.y);
      return offset;
    }
  }
}