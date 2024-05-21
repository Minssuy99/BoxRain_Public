using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 0f;

    protected Animator animator;

    private AudioSource audioSource;
    private static readonly int ishit = Animator.StringToHash("IsHit");

    [SerializeField] private string destroy_Sound;
    [SerializeField] private string GameOver_Sound;

    public GameObject bigBoxPrefab;
    public string smallBoxTag = "Rain"; // 작은 상자의 태그

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        float x = Random.Range(-11f, 11f); // 범위 확장.
        float y = 7.0f;

        transform.position = new Vector3(x, y, 0);

        size = 0.8f;

        transform.localScale = new Vector3(size, size, 0);

        // 상자끼리의 충돌 무시
        IgnoreCollisionsWithOtherRainBoxes();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ++GameManager.Instance.score;
            ++GameManager.Instance.levelscore;
            animator.SetBool(ishit, true);
            SoundManager.instance.PlaySE(destroy_Sound);
        }
        else if (collision.gameObject.tag == "Player")
        {
            animator.SetBool(ishit, true);
            SoundManager.instance.PauseBGM();  // BGM 일시정지
            SoundManager.instance.PlaySE(GameOver_Sound);
            DestroyAllRainBoxes();  // 맵에 있는 모든 Rain 태그를 가진 상자 제거

            // 큰 상자 생성
            Vector3 bigBoxPosition = new Vector3(0, 8, 0);
            Instantiate(bigBoxPrefab, bigBoxPosition, Quaternion.identity);

            // 게임 오버
            GameManager.Instance.GameOver(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Rain")
        {
            // Do nothing if colliding with another Rain box
            // 상자끼리 충돌할 때는 아무것도 하지 않음
        }
        else
        {
            animator.SetBool(ishit, true);
        }
    }

    private void IgnoreCollisionsWithOtherRainBoxes()
    {
        GameObject[] rainBoxes = GameObject.FindGameObjectsWithTag(smallBoxTag);
        Collider2D currentCollider = GetComponent<Collider2D>();

        foreach (GameObject rainBox in rainBoxes)
        {
            if (rainBox != gameObject)
            {
                Collider2D otherCollider = rainBox.GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(currentCollider, otherCollider);
            }
        }
    }

    private void DestroyAllRainBoxes()
    {
        GameObject[] rainBoxes = GameObject.FindGameObjectsWithTag(smallBoxTag);
        foreach (GameObject rainBox in rainBoxes)
        {
            Destroy(rainBox);
        }
    }
}
