
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] _looserTampon;
    [SerializeField] private GameObject[] _couronne;
    [SerializeField] private Text _victoryText;

    public ParticleSystem presidentParticleSystem;


    private void Start()
    {
        StartCoroutine(ReloadGame());
    }

    private IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("MainScene");
    }

    public void SetVictoryDefeat(bool isWin)
    {
        Destroy(presidentParticleSystem.gameObject);
        if (isWin)
        {
            _looserTampon[0].SetActive(true);
            _looserTampon[1].SetActive(true);
            _looserTampon[3].SetActive(true);
            _couronne[2].SetActive(true);
            _victoryText.text = "Victory";

        }
        else
        {
            _couronne[0].SetActive(true);
            _looserTampon[1].SetActive(true);
            _looserTampon[2].SetActive(true);
            _looserTampon[3].SetActive(true);
            _victoryText.text = "Defeat";
        }
        
    }
}
