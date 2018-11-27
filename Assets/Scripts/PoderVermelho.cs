using UnityEngine;
using System.Collections;

public class PoderVermelho : MonoBehaviour {

	public float velocidade;
	public float dano;
	public GameObject explosao;


	void Start () {
		
	}
	void Update () {
		transform.Translate (velocidade * Time.deltaTime, 0f, 0f);
		Destroy (gameObject, 5f);
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("Personagem")){
			Instantiate(explosao,new Vector3 (transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation);

			if (other.gameObject.GetComponent<ControlePersonagem> ().vida <= dano) {
				other.gameObject.GetComponent<ControlePersonagem> ().morrer ();
				other.gameObject.SetActive (false);
				other.gameObject.GetComponent<ControlePersonagem> ().vida -= dano;
			}else
				other.gameObject.GetComponent<ControlePersonagem> ().vida -= dano;

			Destroy (gameObject);
		}
	}
}
