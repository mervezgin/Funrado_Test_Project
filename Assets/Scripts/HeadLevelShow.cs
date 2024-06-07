using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadLevelShow : MonoBehaviour
{
    [SerializeField] Transform characterTransform; //Karakterin world spaceteki pozisyonunu rotasyonunu ve ölçüsünü belirtir.
    [SerializeField] Vector3 offset; //Karaketerin başının üzerindeki text konumunu ayarlamak için.
    [SerializeField] Text levelText; // Karakterin başının üzerindeki UI text objesi.

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(characterTransform.position + offset); //characterTransforma offset eklenir. ve bu world spaceteki konum, screen spaceteki konuma dönüştürülür.
        levelText.transform.position = screenPosition; //levelText doğru yere konumlandırılır.
    }

    public void SetLevel(int level)
    {
        levelText.text = "LVL. " + level; // Karakterin başının üzerindeki konum yazılır.
    }
}
