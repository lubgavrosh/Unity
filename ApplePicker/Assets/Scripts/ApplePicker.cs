using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketButtonY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO=Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;

            pos.y = basketButtonY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }
    public void AppleDestroyed()
    { //a
      // ”далить все упавшие €блоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // b
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        int basketindex = basketList.Count-1;
        GameObject tBasketGO = basketList[basketindex];
        basketList.RemoveAt(basketindex);
        Destroy(tBasketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
        
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
