using UnityEngine;
using System.Collections;

public class PoderRoxo : MonoBehaviour {

	public float dano, forcaAtaque;
	public GameObject explosao;
	public Vector2 angulo;

	private Rigidbody2D rb2d;
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		rb2d.AddForce (angulo*forcaAtaque, ForceMode2D.Impulse);
	}

	void Update () {
		Destroy (gameObject, 5f);
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("Personagem")){
			Instantiate(explosao,new Vector3 (transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation);

			if (other.gameObject.GetComponent<ControlePersonagem> ().vida <= dano) {
				other.gameObject.GetComponent<ControlePersonagem> ().morrer ();
				other.gameObject.SetActive(false);
				other.gameObject.GetComponent<ControlePersonagem> ().vida -= dano;
			}else
				other.gameObject.GetComponent<ControlePersonagem> ().vida -= dano;

			Destroy (gameObject);
		}
	}
}
