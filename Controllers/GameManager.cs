using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    public SaveSystem saveSystem;
    public GameObject Shotbox;//발사되는 상자
    public GameObject rain;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameUIs;
    [SerializeField] private GameObject soundManagerPrefab;
    public GameObject PauseMenu;
    public int score;
    public Text totalScoreTxt;
    public bool isGameOver = false; // 게임이 종료되었는지 여부를 나타내는 변수

    private void Awake()
    {
        saveSystem = GetComponent<SaveSystem>();
        if (SoundManager.instance == null)  // SoundManager 인스턴스가 없으면 프리팹 인스턴스화
        {
            Instantiate(soundManagerPrefab);
        }
    }
    void Start()
    {
        Instantiate(gameUIs, GameObject.Find("Canvas").transform);
        InvokeRepeating("MakeRain", 0f, 1f);
        InvokeRepeating("MakeShotBox", 3f, 3f); // 발사 상자 생성 주기
        score = 0;
    }

    void MakeRain()
    {
        if (!isGameOver) // 게임이 종료되지 않았을 때만 상자 생성
        {
            float x = Random.Range(-11f, 11f); // 범위 확장
            Vector3 spawnPosition = new Vector3(x, 5.0f, 0);
            Instantiate(rain, spawnPosition, Quaternion.identity);
        }
    }

    void MakeShotBox()
    {
        if (!isGameOver)
        {
            float y = Random.Range(-3f, 0f);
            Vector3 spawnPosition = new Vector3(-11f, y, 0);
            Instantiate(Shotbox, spawnPosition, Quaternion.identity);
        }
    }

    public IEnumerator ScreenShake()
    {
        float duration = 0.5f;
        float magnitude = 0.3f; // 흔들림 강도
        Vector3 originalPos = Camera.main.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = originalPos; // 흔들림이 끝나면 카메라 위치를 원래대로 돌림
    }

    public void GameOver(GameObject player)
    {
        BoxCollider2D playerCollider = player.GetComponent<BoxCollider2D>();
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerCollider.enabled = false; // 플레이어의 콜라이더 끄기
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        player.GetComponent<TopDownMovement>().enabled = false;

        StartCoroutine(ScreenShake()); // 상자가 나타나자마자 화면 흔들기
        isGameOver = true; // 게임 종료 상태로 변경

        saveSystem.SaveScore();
        Invoke("SpawnGameOverMenu", 1.2f);
    }

    private void SpawnGameOverMenu()
    {
        Instantiate(gameOverUI, GameObject.Find("Canvas").transform);
    }
}
