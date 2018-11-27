using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlePersonagem : MonoBehaviour {

	public float vida;
	public float velocidadeMovimento, forcaPulo;
	public GameObject controleCenario;
	public static float corretorPosicao = 4f;
	public GameObject poderPersonagem;
	public Transform saidaPoder;
	public float cronometro = 1;
	public float tempoAtaque = 1;
	public GameObject barraVida;
	public GameObject controleCenas;

	private Animator animator;
	private Rigidbody2D rb2d;
	private int pulos;
	private AudioSource audioSource;


	void Start () {
		Cursor.visible = false;
		animator = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		if (vida > 100f) {
			vida = 100f;
		}

		barraVida.transform.localScale = new Vector3 (0.01f * vida, 1f, 0f);

		movimentar ();

		if (Input.GetKeyDown (KeyCode.Space) && pulos < 1) {
			pular ();
			pulos++;
		}

		if (Input.GetKeyDown (KeyCode.K) && cronometro >= tempoAtaque) {
			atacar ();
			cronometro = 0;
		}
		cronometro += Time.deltaTime;

		if(vida <= 0){
			Debug.Log("PERDEU");
		}
	}

	public void movimentar(){
		float h = Input.GetAxis ("Horizontal");

		if (h > 0f) {
			if (!animator.GetBool ("estaPulando")) {
				animator.SetBool ("estaAndando", true);
				animator.SetBool ("estaParado", false);
			}
			transform.localScale = new Vector3 (1f, 1f, 0f);
		} else if (h < 0f) {
			transform.localScale = new Vector3 (-1f, 1f, 0f);
			if (!animator.GetBool ("estaPulando")) {
				animator.SetBool ("estaAndando", true);
				animator.SetBool ("estaParado", false);
			}
		} else {
			animator.SetBool ("estaAndando", false);
			animator.SetBool ("estaParado", true);
		}

		//Impede que o personagem saia dos limites do cenario
		float limiteE = controleCenario.GetComponent<ControleCenario> ().xCenarioLimiteEsquerdo - ControleCenario.distanciaEntreCenarios / 2;
		float limiteD = controleCenario.GetComponent<ControleCenario> ().xCenarioLimiteDireito + ControleCenario.distanciaEntreCenarios / 2;

		if ((transform.position.x > limiteE) && (transform.position.x < limiteD))
			transform.Translate (h * velocidadeMovimento * Time.deltaTime, 0f, 0f);
		else{
			if(transform.position.x < limiteE)
				transform.position += new Vector3 (0.01f, 0f, 0f);
			else
				transform.position += new Vector3 (-0.01f, 0f, 0f);
		}
	}

	public void pular(){
		animator.SetBool ("estaPulando", true);
		animator.SetBool ("estaParado", false);
		animator.SetBool ("estaAndando", false);
		rb2d.AddForce (Vector2.up * forcaPulo, ForceMode2D.Impulse);
	}

	public void atacar(){
		animator.SetBool ("estaAtacando", true);
		animator.Play ("Atacando");
		animator.SetBool ("estaAtacando", false);
		audioSource.Play ();
		Instantiate (poderPersonagem, saidaPoder.position, saidaPoder.rotation);
	}

	void OnCollisionEnter2D (Collision2D coll){
		animator.SetBool ("estaPulando", false);
		pulos = 0;
	}

	public void morrer(){
		SceneManager.LoadScene ("GameOverPerdeu");
	}

	public void ganhou(){
		SceneManager.LoadScene ("GameOverGanhou");
	}
}
