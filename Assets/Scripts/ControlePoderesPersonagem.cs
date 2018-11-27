using UnityEngine;
using System.Collections;

public class ControlePoderesPersonagem : MonoBehaviour {

	public float dano;
	public float velocidade;
	public GameObject explosao;

	private GameObject personagem;

	void Start () {
		dano = 50f;
		personagem = GameObject.FindGameObjectWithTag ("Personagem");
		if (personagem.transform.localScale.x > 0) {
			velocidade *= 1;
			transform.localScale = new Vector3(1f,1f,0f);
		} else {
			if (personagem.transform.localScale.x < 0) {
				velocidade *= -1;
				transform.localScale = new Vector3 (-1f,1f,0f);
			}
		}
	}

	void Update () {
		transform.Translate (velocidade * Time.deltaTime, 0f, 0f);
		Destroy (gameObject, 5f);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.CompareTag ("Inimigo")) {
			Instantiate (explosao, new Vector3 (transform.position.x + 1f, transform.position.y, transform.position.z), transform.rotation);

			if (other.gameObject.GetComponent<ControleInimigo1> ().vida <= dano) {
				Destroy (other.gameObject);
				ControleSpawn.quantidadeInimigo1--;
			} else
				other.gameObject.GetComponent<ControleInimigo1> ().vida -= dano;
			
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

			Destroy (gameObject);
		} else {
			if (other.CompareTag ("Inimigo2")) {
				Instantiate (explosao, new Vector3 (transform.position.x + 1f, transform.position.y, transform.position.z), transform.rotation);

				if (other.gameObject.GetComponent<ControleInimigo2> ().vida <= dano) {
					Destroy (other.gameObject);
					ControleSpawn.quantidadeInimigo2--;
				} else
					other.gameObject.GetComponent<ControleInimigo2> ().vida -= dano;

				gameObject.GetComponent<SpriteRenderer> ().enabled = false;

				Destroy (gameObject);
			} else {
				if(other.CompareTag("Inimigo3")){
					Instantiate(explosao,new Vector3 (transform.position.x + 1f, transform.position.y, transform.position.z), transform.rotation);

					if (other.gameObject.GetComponent<ControleInimigo3> ().vida <= dano) {
						Destroy (other.gameObject);
						ControleSpawn.quantidadeInimigo3--;
					}else
						other.gameObject.GetComponent<ControleInimigo3> ().vida -= dano;

					gameObject.GetComponent<SpriteRenderer> ().enabled = false;

					Destroy (gameObject);
				}
			}
		}
	}
}
