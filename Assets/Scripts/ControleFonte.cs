using UnityEngine;
using System.Collections;

public class ControleFonte : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.CompareTag ("Personagem")) {
			FindObjectOfType<ControlePersonagem> ().ganhou ();
		}
	}
}
