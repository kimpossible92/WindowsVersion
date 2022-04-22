using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        bool MouseHeel=false; 
        float pointrot = 0f; float pointrot2 = 0;
        Vector2 _moveDirection; 
        public void OnMove()
        {
            if (GetComponent<CollShip>()._pause) 
            {
                _moveDirection = Vector3.zero;
                return; 
            }
            float hMove = Input.GetAxis("Horizontal");
            float vMove = Input.GetAxis("Vertical");
            _moveDirection = new Vector2(hMove,vMove);
        }
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            OnMove();
            //if (_moveDirection.y < 0) { return; }
            pointrot += _moveDirection.x * Time.deltaTime * -100;
            movementSystem.LateralRotate(pointrot);
            movementSystem.LongMovement(_moveDirection.y);
            
            //if(
            //   transform.position.x<GetComponent<CollShip>().limitx||
            //   transform.position.x>GetComponent<CollShip>().limitx1
            //   )
            //{
            //    movementSystem.LateralMovement(Input.GetAxis("Horizontal") * Time.deltaTime);
            //    if (MouseHeel) { /*print((Input.mousePosition.x * 0.1f) - 50);*/ transform.position = new Vector3((Input.mousePosition.x*0.1f)-40, transform.position.y, transform.position.z); }
            //}
            //if(
            //   transform.position.x > GetComponent<CollShip>().limitx)
            //{
            //    //print("x");
            //    transform.position = new Vector3(GetComponent<CollShip>().limitx-2, transform.position.y, transform.position.z);
            //}

            //if(transform.position.x < GetComponent<CollShip>().limitx1
            //   )
            //{
            //    //print("x1");
            //    transform.position = new Vector3(GetComponent<CollShip>().limitx1 + 2, transform.position.y, transform.position.z);
            //}

        }
      
        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space)|| Input.GetMouseButton(0))
            {
                fireSystem.TriggerFire();
                var source = GetComponent<AudioSource>();
                if(source !=null)source.PlayOneShot(source.clip);
            }
            if (Input.GetKey(KeyCode.M))
            {
                MouseHeel = true;
            }
            if (Input.GetKey(KeyCode.N))
            {
                MouseHeel = false;
            }
        }
       
    }
}
