using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        Camera camera = Camera.main; //Main Camerayı referans aldım.
        float targetAspect = 1080.0f / 1920.0f; //Hedef görüntü oranı tanımladım.
        float windowAspect = (float)Screen.width / (float)Screen.height; //Mevcut(windowAspect) ekranın görüntü oranını hesapladım.
        float scaleHeight = windowAspect / targetAspect; //Mevcut ekran oranının(windowAspect) targetAspecte göre yüksekliğini hesapladım.

        //Yüksekliği küçültmek için 
        if (scaleHeight < 1.0f) // Eğer mevcut ekran oranı(windowAspect) hedef orandan(targetAspect) genişse yüksekliği küçültmek gerekir.
        {
            Rect rect = camera.rect; // Kameranın şu anki(width ve height değeriyle) dikdörtgenini (rect) bir variable atadım.
            rect.width = 1.0f; //Genişliği %100 yapar.
            rect.height = scaleHeight; // Yüksekliği ölçeklendirir.
            rect.x = 0; // X ekseninde kaydırma yapmaması için 0'a eşitledim.
            rect.y = (1.0f - scaleHeight) / 2.0f; //Y ekseninde görüntüyü ortalaması için 1.0f dan scaleHeigt i çıkarıp 2ye böldüm.
            camera.rect = rect; // Yeni width ve height değerlerini(rect) Main Cameraya uygular.
        }
        else //Genişliği küçültmek için         
        {
            float scaleWidth = 1.0f / scaleHeight; //Genişliği ölçeklendirdim.
            Rect rect = camera.rect;// Kameranın şu anki(width ve height değeriyle) dikdörtgenini (rect) bir variable atadım. 
            rect.width = scaleWidth;// Genişliği ölçeklendirir.
            rect.height = 1.0f; //Yüksekliği %100 yapar.
            rect.x = (1.0f - scaleWidth) / 2.0f; //X ekseninde görüntüyü ortalar.
            rect.y = 0; //Y ekseninde kaydırma yapmaması için 0'a eşitledim.
            camera.rect = rect; // Yeni width ve height değerlerini(rect) Main Cameraya uygular.
        }
    }
}
