using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject kurang, bagi, tambah, kali, hitung, banding;
    public Canvas canvas;

    void Start()
    {
        string prevScene = SceneMan.prevScene;
        switch (prevScene)
        {
            case "kurang": Kurang(); break;
            case "bagi": Bagi(); break;
            case "tambah": Tambah(); break;
            case "kali": Kali(); break;
            case "hitung": Hitung(); break;
            case "banding": Banding(); break;
        }
    }

    public void Kurang()
    {
        GameObject obj = Instantiate(kurang);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-170,0,0);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        if(!PlayerPrefs.HasKey("playerDataKurang"))
        {
            PlayerPrefs.SetInt("playerDataKurang", 0);
            int l = PlayerPrefs.GetInt("playerDataKurang");
            Debug.Log("playerprefkurang : " + l);
        }
    }
    
    public void Tambah()
    {
        GameObject obj = Instantiate(tambah);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-170,0,0);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        int scoreTambah;
        if(!PlayerPrefs.HasKey("playerDataTambah"))
        {
            PlayerPrefs.SetInt("playerDataTambah", 15);
            scoreTambah = PlayerPrefs.GetInt("playerDataTambah");
            Debug.Log("Score Tambah : " + scoreTambah);
        }
    }
    public void Kali()
    {
        GameObject obj = Instantiate(kali);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-170,0,0);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        
    }
    public void Bagi()
    {
        GameObject obj = Instantiate(bagi);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-170,0,0);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
    }
    
    public void Hitung()
    {
        GameObject objToDestroy = GameObject.Find("Answer Area"); 
        GameObject objToDestroy2 = GameObject.Find("Pilih Jawaban Text"); 
        GameObject objToDestroy3 = GameObject.Find("Perintah"); 
        if (objToDestroy != null)
        {
            Destroy(objToDestroy);
            Destroy(objToDestroy2);
            Destroy(objToDestroy3);
        }
        GameObject obj = Instantiate(hitung);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        obj.transform.localScale = new Vector3(1.3f, 1.3f, 0f);

    }
    
    public void Banding()
    {
        GameObject objToDestroy = GameObject.Find("Answer Area"); 
        GameObject objToDestroy2 = GameObject.Find("Pilih Jawaban Text"); 
        GameObject objToDestroy3 = GameObject.Find("Perintah"); 
        if (objToDestroy != null)
        {
            Destroy(objToDestroy);
            Destroy(objToDestroy2);
            Destroy(objToDestroy3);
        }
        GameObject obj = Instantiate(banding);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        obj.transform.localScale = new Vector3(1.3f, 1.3f, 0f);

    }
}