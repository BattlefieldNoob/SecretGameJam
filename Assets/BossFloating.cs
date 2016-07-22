using UnityEngine;
using System.Collections;

public class BossFloating : MonoBehaviour {

	 public float waterLevel = 0f;
 public float floatHeight = 2;
 public float bounceDamp = 0.05f;
 public Vector3 buoyancyCentreOffset;
 private float forceFactor;
 private Vector3 actionPoint;
 private Vector3 uplift; 

	 void OnTriggerStay2D(Collider2D Hit)
 {
     actionPoint = Hit.transform.position + Hit.transform.TransformDirection(buoyancyCentreOffset);
     forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
     if(forceFactor > 0f){
		 uplift = -Physics.gravity * (forceFactor - Hit.GetComponent<Rigidbody2D>().velocity.y * bounceDamp);
         Hit.GetComponent<Rigidbody2D>().AddForceAtPosition(uplift, actionPoint);
     }
 }
}
