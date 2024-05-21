using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBox : MonoBehaviour
{
    [SerializeField] private string destroy_Sound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            SoundManager.instance.PlaySE(destroy_Sound);
            StartCoroutine(ResumeBGMWithDelay(0.7f));
            StartCoroutine(GameManager.Instance.ScreenShake()); // GameManager.cs 의 ScreenShake 메서드. 화면떨림.
        }
    }

    private IEnumerator ResumeBGMWithDelay(float delay) // 브금 시작 지연시키기
    {
        yield return new WaitForSeconds(delay);
        SoundManager.instance.ResumeBGM();
    }
}
