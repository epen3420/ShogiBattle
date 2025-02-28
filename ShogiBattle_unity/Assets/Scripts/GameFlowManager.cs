using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] komas;


    private void Start()
    {
        GameLoop().Forget();
    }

    private async UniTask GameLoop()
    {
        // 駒を設置
        // カメラを移動
        /*
        while (!誰か死んだ)
        {
            // 入力のループ
        }

        if (!駒のグレードが最後か)
        {
            // 駒を全部破壊
            // 駒のグレードを変更
            GameLoop();
        }
        else
        {
            // ゲーム終了
        }
        */

        await UniTask.CompletedTask;
    }
}
