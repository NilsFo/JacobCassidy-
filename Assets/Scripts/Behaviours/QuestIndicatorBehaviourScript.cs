using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIndicatorBehaviourScript : MonoBehaviour
{

    public SpriteRenderer renderer;
    public GameObject player;
    
    private List<CultistAI> list;
    private CultistAI chosen = null;
    
    [SerializeField] private float scanDelay = 2f;
    [SerializeField] private float scanTimer = 0f;

    private bool isAktie = true;
    
    // Start is called before the first frame update
    void Start()
    {
        scanTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosed();
        if (scanTimer <= 0)
        {
            scanTimer = scanDelay;
        }
        else
        {
            scanTimer -= Time.deltaTime;
        }
    }

    private void FindClosed()
    {
        if (!isAktie)
        {
            renderer.enabled = false;
            return;
        }
        if (scanTimer < 0)
        {
            var result = FindObjectsOfType<CultistAI>();
            list = new List<CultistAI>(result);

            float lastdist = 999999999;
            foreach (var cultistAI in list)
            {
                float dist = Vector2.Distance(cultistAI.gameObject.transform.position, player.transform.position);
                if (dist < lastdist)
                {
                    chosen = cultistAI;
                    Debug.Log("Chosen !!!");
                }
            }
        }
        

        if (chosen != null)
        {
            Debug.Log("Rotation!");
            var direction = chosen.gameObject.transform.position - player.transform.position;
            var rotaion = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);

            transform.rotation = rotaion;
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
    }
}