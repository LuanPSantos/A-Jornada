using UnityEngine;
using System.Collections;

public class ControleInimigo3 : MonoBehaviour {

	public float vida, dano, velocidade;
	public GameObject explosao;
	public GameObject barraVida;
	private AudioSource audioSource;
	private float cronometro;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		transform.Translate (-velocidade * Time.deltaTime, 0f, 0f);
		barraVida.transform.localScale = new Vector3 (0.01f * vida, 1f, 0f);
		if (cronometro >= 1.5f) {
			audioSource.Play ();
			cronometro = 0;
		}
		cronometro += Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other){

		if(other.CompareTag("Personagem")){
			Instantiate(explosao,transform.position, transform.rotation);

			if (other.gameObject.GetComponent<ControlePersonagem> ().vida <= dano) {
				other.gameObject.GetComponent<ControlePersonagem> ().morrer ();
				other.gameObject.SetActive (false);
				other.gameObject.GetComponent<ControlePersonagem> ().vida -= dano;
			}else
				other.gameObject.GetComponent<ControlePersonagem> ().vida -= dano;

			ControleSpawn.quantidadeInimigo3--;
			Destroy (gameObject);
		}
	}
}
