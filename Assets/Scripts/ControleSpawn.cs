using UnityEngine;
using System.Collections;

public class ControleSpawn : MonoBehaviour {

	public float alturaMinimaSpawn, alturaMaximaSpawn, distanciaSpawn1,distanciaSpawn2,distanciaSpawn3, tempoSpawn1, tempoSpawn2, tempoSpawn3;
	public GameObject inimigo1, inimigo2, inimigo3, vida;
	public Transform cameraTransform;
	public bool spawnarInimigo1, spawnarInimigo2, spawnarInimigo3;
	public static int quantidadeInimigo1 = 0, quantidadeInimigo2 = 0, quantidadeInimigo3 = 0, quantidadeVida = 0;
	public float tempoSpawnVida;

	private float cronometro, cronometro1, cronometro2, cronometro3;
	void Start () {
	}

	void Update () {
		if (cameraTransform.position.x > distanciaSpawn1) {
			spawnarInimigo1 = true;
		}
		if (cameraTransform.position.x > distanciaSpawn2) {
			spawnarInimigo2 = true;
		}
		if (cameraTransform.position.x > distanciaSpawn3) {
			spawnarInimigo3 = true;
		}

		if (quantidadeInimigo1 < 1 && spawnarInimigo1 == true && cronometro1 > tempoSpawn1) {
			Instantiate (inimigo1, new Vector3 (cameraTransform.position.x + ControleCenario.distanciaEntreCenarios, Random.Range (alturaMinimaSpawn, alturaMaximaSpawn)), transform.rotation);
			quantidadeInimigo1++;
			cronometro1 = 0;
		}
		if (quantidadeInimigo2 < 1 && spawnarInimigo2 == true && cronometro2 > tempoSpawn2) {
			Instantiate (inimigo2, new Vector3 (cameraTransform.position.x + ControleCenario.distanciaEntreCenarios, inimigo2.transform.position.y, inimigo2.transform.position.z), inimigo2.transform.rotation);
			quantidadeInimigo2++;
			cronometro2 = 0;
		}
		if (quantidadeInimigo3 < 1 && spawnarInimigo3 == true && cronometro3 > tempoSpawn3) {
			Instantiate (inimigo3, new Vector3 (cameraTransform.position.x + ControleCenario.distanciaEntreCenarios, inimigo3.transform.position.y, inimigo3.transform.position.z), inimigo3.transform.rotation);
			quantidadeInimigo3++;
			cronometro3 = 0;
		}

		if (cronometro >= tempoSpawnVida && quantidadeVida < 1) {
			Instantiate (vida, new Vector3 (cameraTransform.position.x + ControleCenario.distanciaEntreCenarios + 10f, vida.transform.position.y, vida.transform.position.z), transform.rotation);
			cronometro = 0;
			quantidadeVida++;
		}
		

		cronometro += Time.deltaTime;
		cronometro1 += Time.deltaTime;
		cronometro2 += Time.deltaTime;
		cronometro3 += Time.deltaTime;
	}
}
