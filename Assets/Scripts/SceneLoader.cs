using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject kurang;
    public GameObject bagi;
    public GameObject tambah;
    public GameObject kali;
    public GameObject hitung;
    public GameObject banding;
    public Canvas canvas;

    void Start()
    {
        if (SceneMan.prevScene == "kurang")
        {
            Kurang();
        }
        else if (SceneMan.prevScene == "bagi")
        {
            Bagi();
        }
        else if (SceneMan.prevScene == "tambah")
        {
            Tambah();
        }
        else if (SceneMan.prevScene == "kali")
        {
            Kali();
        }
        else if (SceneMan.prevScene == "banding")
        {
            Banding();
        }
        else if (SceneMan.prevScene == "hitung")
        {
            Hitung();
        }
    }

    void Kurang()
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
    void Tambah()
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
    void Kali()
    {
        GameObject obj = Instantiate(kali);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-170,0,0);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
        
    }
    void Bagi()
    {
        GameObject obj = Instantiate(bagi);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-170,0,0);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);
    }
    
    void Hitung()
    {
        GameObject obj = Instantiate(hitung);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-170,0,0);
        obj.transform.localScale = new Vector3(1f, 1f, 0f);

    }
    
    void Banding()
    {
        GameObject objToDestroy = GameObject.Find("Answer Area"); 
        if (objToDestroy != null)
        {
            Destroy(objToDestroy);
        }
        GameObject obj = Instantiate(banding);
        obj.transform.SetParent(canvas.transform);
        obj.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
        obj.transform.localScale = new Vector3(1.3f, 1.3f, 0f);

    }
}