using UnityEngine;
using System.Collections;

public class ControleInimigo2 : MonoBehaviour {

	public float vida;
	public GameObject poder;
	public Transform saidaPoder;
	public float tempoAtaque;
	public GameObject barraVida;

	private float cronometro;
	private AudioSource audioSource;
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		barraVida.transform.localScale = new Vector3 (0.01f * vida, 1f, 0f);

		if (cronometro >= tempoAtaque) {
			audioSource.Play ();
			Instantiate (poder, saidaPoder.position, saidaPoder.rotation);
			cronometro = 0f;
		}

		cronometro += Time.deltaTime;
	}
}
