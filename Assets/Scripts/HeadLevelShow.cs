using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadLevelShow : MonoBehaviour
{
    [SerializeField] Transform characterTransform; //Karakterin world spaceteki pozisyonunu rotasyonunu ve ölçüsünü belirtir.
    public Vector3 offset; //Karaketerin başının üzerindeki text konumunu ayarlamak için.
    public Text levelText; // Karakterin başının üzerindeki UI text objesi.

    void Update()
    {
        if (levelText != null && characterTransform != null)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(characterTransform.position + offset); //characterTransforma offset eklenir. ve bu world spaceteki konum, screen spaceteki konuma dönüştürülür.
            levelText.transform.position = screenPosition; //levelText doğru yere konumlandırılır.
        }
    }

    public void SetLevel(int level)
    {
        if (levelText != null)
        {
            levelText.text = "LVL. " + level; // Karakterin başının üzerindeki konum yazılır.
        }
    }

    public void HideLevelText()
    {
        if (levelText != null)
        {
            levelText.gameObject.SetActive(false); // Seviye metnini gizle
        }
    }

    public void ShowLevelText()
    {
        if (levelText != null)
        {
            levelText.gameObject.SetActive(true); // Seviye metnini göster
        }
    }
}
