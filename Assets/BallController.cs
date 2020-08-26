using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text Score;
    private int score = 0;

 


    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        score = 0;
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {

        // 大の星10点、小の星20点、大の雲10点、小の雲20点　
        /*.ピリオドは(～の中のという意味)下のother.gameObject.tagはotherの中のgameObjectの中のtagという意味*/
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 20;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 20;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 10;
        }
        SetScore();
    }
    void SetScore()
    {
        Score.text = string.Format("Score:{0}", score);
    }
}