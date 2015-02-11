using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {

    /// <summary>
    /// 2D 用の Transform
    /// </summary>
    private RectTransform rectTransform;

    /// <summary>
    /// Unity lifecycle: Start
    /// </summary>
    public void Start () {
        // 接触判定の際に、自身のサイズを取得したいので、保持しておく
        this.rectTransform = this.gameObject.GetComponent<RectTransform>();
    }

    /// <summary>
    /// Unity lifecycle: Update
    /// </summary>
    public void Update () {
        // Do nothing.
    }

    /// <summary>
    /// 2D オブジェクトの接触開始判定
    /// </summary>
    /// <param name="collision">当たったオブジェクトの当たり判定</param>
    public void OnCollisionEnter2D(Collision2D collision) {
        Vector2 contactPoint = collision.contacts[0].point;
        // 画面上の座標を、自身からみた相対位置に変換する
        float contactPointLocal = this.transform.InverseTransformPoint(contactPoint).x;
        float holizontalForce = contactPointLocal / (this.rectTransform.sizeDelta.x / 2.0f);
        // 上方向に2倍の力を与え、左右方向に相対的な接触位置に応じた力を与える
        collision.gameObject.rigidbody2D.AddForce(Vector2.up * 2.0f + Vector2.right * holizontalForce);
    }

}
