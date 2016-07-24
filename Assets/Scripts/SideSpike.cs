using UnityEngine;
using System.Collections;

public class SideSpike : MonoBehaviour {

	public Sprite[] spikeSp;

	Spike[] spikes;
	public bool goUp;

	public float shiftDistance;

    AudioSource sounds;

	void Start () {
        sounds = GetComponent<AudioSource>();
		spikes=GetComponentsInChildren<Spike>();
		SpriteRenderer[] renderer=GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer sr in renderer){
			sr.sprite=spikeSp[Random.Range(0, 3)];
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
            sounds.Play();
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
