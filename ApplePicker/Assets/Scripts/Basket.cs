using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); 
                                                              
        scoreGT = scoreGO.GetComponent<Text>(); 
                                               
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition; 
                                                  // Координата Z камеры определяет, как далеко в трехмерном пространстве
                                                  // находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z; 
                                                          // Преобразовать точку на двумерной плоскости экрана в трехмерные
                                                          // координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); 
                                                                         // Переместить корзину вдоль оси X в координату X указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    { 
      // Отыскать яблоко, попавшее в эту корзину
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
        Destroy(collidedWith); }
        // Преобразовать текст в scoreGT в целое число
        int score = int.Parse(scoreGT.text); 
                                             // Добавить очки за пойманное яблоко
        score += 100;
        // Преобразовать число очков обратно в строку и вывести ее на экран
        scoreGT.text = score.ToString();
    }
}
