using UnityEngine;
using System.Collections;

public class ControleVida : MonoBehaviour {

	public float vida;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D coll){
		if(coll.gameObject.CompareTag("Personagem")){
			coll.gameObject.GetComponent<ControlePersonagem> ().vida += vida;
			Destroy (gameObject);
			ControleSpawn.quantidadeVida--;
		}
	}
}
