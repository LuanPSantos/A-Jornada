using UnityEngine;
using System.Collections;

public class ControleCenario : MonoBehaviour {

	public GameObject personagem;
	public GameObject castelo,floresta, florestaCampo, campo, fonte;
	public float xCenarioLimiteEsquerdo, xCenarioLimiteDireito;
	public int contagem, limiteFloresta, limiteCampo;
	public static float distanciaEntreCenarios = 20.48f;

	private Vector3 posicaoCenarioAtual, posicaoCenarioLimite;
	private GameObject ultimoSpawnado, cenarioIntermediario, cenarioLimite;
	private bool podeSpawnar = true;

	void Start () {
		cenarioIntermediario = cenarioLimite = Instantiate (castelo, new Vector3 (1f, 0f, 0f), transform.rotation) as GameObject;
		posicaoCenarioAtual = castelo.transform.position;
		ultimoSpawnado = Instantiate (floresta, new Vector3 (posicaoCenarioAtual.x + distanciaEntreCenarios, 0f, 0f), transform.rotation) as GameObject;
	}

	void Update () {

		if (personagem.transform.position.x + ControlePersonagem.corretorPosicao > ultimoSpawnado.transform.position.x && podeSpawnar == true) {
			if (posicaoCenarioAtual.x > cenarioLimite.transform.position.x + distanciaEntreCenarios && podeSpawnar == true) {
				Destroy (cenarioLimite);
				//cenarioLimite = cenarioIntermediario;
			}

			cenarioLimite = cenarioIntermediario;
			cenarioIntermediario = ultimoSpawnado;

			if (contagem < limiteFloresta)
				ultimoSpawnado = Instantiate (floresta, new Vector3 (posicaoCenarioAtual.x + distanciaEntreCenarios, 0f, 0f), transform.rotation) as GameObject;
			else if (contagem == limiteFloresta)
				ultimoSpawnado = Instantiate (florestaCampo, new Vector3 (posicaoCenarioAtual.x + distanciaEntreCenarios, 0f, 0f), transform.rotation) as GameObject;
			else if (contagem > limiteFloresta && contagem < limiteCampo) {
				ultimoSpawnado = Instantiate (campo, new Vector3 (posicaoCenarioAtual.x + distanciaEntreCenarios, 0f, 0f), transform.rotation) as GameObject;
			}else {
				ultimoSpawnado = Instantiate (fonte, new Vector3 (posicaoCenarioAtual.x + distanciaEntreCenarios, 0f, 0f), transform.rotation) as GameObject;
				podeSpawnar = false;
			}
			contagem++;


		} 

		xCenarioLimiteEsquerdo = cenarioLimite.transform.position.x;
		xCenarioLimiteDireito = ultimoSpawnado.transform.position.x;
	}

	void FixedUpdate(){
		RaycastHit2D hit = Physics2D.Raycast (personagem.transform.position, Vector2.down);
		if (hit.collider != null) {
			posicaoCenarioAtual = hit.transform.position;
		}
	}
}
