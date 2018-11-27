using UnityEngine;
using System.Collections;

public class ControleCamera : MonoBehaviour {

	public GameObject personagem;
	public GameObject controleCenario;
	void Start () {
	
	}

	void LateUpdate () {
		if((personagem.transform.position.x > controleCenario.GetComponent<ControleCenario>().xCenarioLimiteEsquerdo - 1f - ControlePersonagem.corretorPosicao) &&
			(personagem.transform.position.x < controleCenario.GetComponent<ControleCenario>().xCenarioLimiteDireito + 1f - ControlePersonagem.corretorPosicao))
			transform.position = new Vector3(personagem.transform.position.x + ControlePersonagem.corretorPosicao, transform.position.y, transform.position.z);
	}
}
