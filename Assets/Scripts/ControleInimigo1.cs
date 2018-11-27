using UnityEngine;
using System.Collections;

public class ControleInimigo1 : MonoBehaviour {

	public float vida;
	public GameObject poder;
	public Transform saidaPoder;
	public float cronometro = 1, cronometro2;
	public float tempoAtaque = 1;
	public float velocidadeVertical, VelocidadeHorizontal, direcao;
	public GameObject barraVida;
	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {

		barraVida.transform.localScale = new Vector3 (0.01f * vida, 1f, 0f);

		if (cronometro >= tempoAtaque) {
			atacar ();
			cronometro = 0;
		}
		cronometro += Time.deltaTime;

		if (Mathf.FloorToInt(cronometro2) % 2 == 0)
			direcao = -1;
		else
			direcao = 1;

		cronometro2 += Time.deltaTime;

		transform.Translate (-VelocidadeHorizontal * Time.deltaTime, velocidadeVertical * direcao * Time.deltaTime, 0f);
	}

	public void atacar(){
		audioSource.Play ();
		Instantiate (poder, saidaPoder.position, saidaPoder.rotation);
	}
}
