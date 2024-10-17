using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int minTime;
    public int maxTime;

    float currTime;
    int random = 1;

    public float score = 0;

    public Text ScoreTExt;

    public ItemPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 1.5f;
        ScoreTExt.text = string.Format("{0:N1}", score);

        currTime += Time.deltaTime;

        if (currTime > random)
        {
            GameObject item = objectPool.GetPooledObject();

            item.gameObject.SetActive(true);
            currTime = 0;
            random = Random.Range(minTime, maxTime);
            Debug.Log(random);
        }

    }


}


