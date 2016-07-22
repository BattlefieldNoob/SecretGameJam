using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	public float delta;

	Vector2 startPosition;

	bool animate=false;

	public float speed;

	public void AnimateSpike(bool goUp){
		//la punta deve alzarsi di delta pixel e tornare indietro
		animate=true;
		StartCoroutine(Animation(goUp));
	}

	public bool IsAnimating(){
		return animate;
	}

	IEnumerator Animation(bool goUp){
		startPosition=transform.position;
		Vector2 maxPosition=startPosition+new Vector2(0,goUp?delta:-delta);
		while(Vector2.Distance(transform.position,maxPosition)>0.005f){
			transform.position=Vector2.Lerp(transform.position,maxPosition,Time.deltaTime*speed);
			yield return new WaitForEndOfFrame();
		}
		while(Vector2.Distance(transform.position,startPosition)>0.005f){
			transform.position=Vector2.Lerp(transform.position,startPosition,Time.deltaTime*speed);
			yield return new WaitForEndOfFrame();
		}
		animate=false;
		yield break;
	}
}
