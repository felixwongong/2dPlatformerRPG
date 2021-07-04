using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Movement
{
    public class Mover : MonoBehaviour
    {
        //config para
        [SerializeField] float moveSpeed = 10f;
        
        Rigidbody2D rb2D = null;

        private void Start() {
            rb2D = GetComponent<Rigidbody2D>();
        }


        /*
        There are 3 approach of 2d platformer movement
        1, use Kinematic rigidbody & transform.Translate() or other method directly changing transform.position
        2, use Dynamic rigidbody by updating rigidbody.velocity            
        3, use Dynamic rigidbody to apply force to the rigidbody aka Rigidbody.addForce()
        */
        public void move(float moveDirection){
            rb2D.velocity = new Vector2(moveDirection * moveSpeed, 0);
        }
    }
}
