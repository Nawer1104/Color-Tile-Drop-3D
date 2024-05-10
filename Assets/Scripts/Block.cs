using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Block : MonoBehaviour
{
    private bool isClicked;

    private Vector3 targetPos;

    public GameObject vfxDestroy;

    private void Awake()
    {
        isClicked = false;
    }

    private void Start()
    {
        targetPos = GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].target.position;
    }

    private void OnMouseDown()
    {
        if (isClicked)
            return;

        isClicked = true;

        transform.DOMove(targetPos, 1f).OnComplete(() => {
            GameObject vfx = Instantiate(vfxDestroy, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            transform.DOScale(0, 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
        });
    }
}
