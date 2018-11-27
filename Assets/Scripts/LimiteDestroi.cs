using UnityEngine;
using System.Collections;

public class LimiteDestroi : MonoBehaviour {

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.CompareTag ("Inimigo")) {
			Destroy (coll.gameObject);
			ControleSpawn.quantidadeInimigo1--;
		}

		if(coll.gameObject.CompareTag ("Inimigo2")){
			ControleSpawn.quantidadeInimigo2--;
			Destroy (coll.gameObject);
		}

		if(coll.gameObject.CompareTag ("Inimigo3")){
			ControleSpawn.quantidadeInimigo3--;
			Destroy (coll.gameObject);
		}
	}
}
