using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CrontroleCenas : MonoBehaviour {
	void Start(){
		Cursor.visible = true;
	}
	void Update(){
	}
	public void iniciar(){
		SceneManager.LoadScene ("Historia");
	}
	public void sair(){
		Application.Quit ();
	}
	public void irInicar(){
		SceneManager.LoadScene ("Game");
	}
	public void menu(){
		SceneManager.LoadScene ("Menu");
	}
	public void creditos(){
		SceneManager.LoadScene ("Creditos");
	}
}
