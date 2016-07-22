using UnityEngine;
using System.Collections;

public class SideSpike : MonoBehaviour {

	public Sprite spike;

	Spike[] spikes;
	public bool goUp;

	public float shiftDistance;

	void Start () {
		spikes=GetComponentsInChildren<Spike>();
		SpriteRenderer[] renderer=GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer sr in renderer){
			sr.sprite=spike;
		}
		StartCoroutine(Spikes());
	}

	IEnumerator Spikes(){
		yield return new WaitForSeconds(1f);
		for(int i=0;i<6;i++){//mostro 6 punte
			foreach (Spike spike in spikes)
			{
				spike.AnimateSpike(goUp);
			}
			while(spikes[0].IsAnimating() || spikes[1].IsAnimating()){
				yield return new WaitForEndOfFrame();
			}
			TranslateSpikes();
		}
        Destroy(gameObject.transform.parent.gameObject);
	}

	void TranslateSpikes(){
		spikes[0].transform.Translate(new Vector2(shiftDistance,0));
		spikes[1].transform.Translate(new Vector2(-shiftDistance,0));
	}
}
