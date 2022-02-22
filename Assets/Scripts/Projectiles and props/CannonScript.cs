using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public Vector3 rotation;

    private GameObject musicPlayer;
    public List<Transform> spawners;

    public List<float> kickSpawnTempo;

    private string directory;
    private string songFolder;


    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        directory = $"{Application.streamingAssetsPath}/SongsData/";
        musicPlayer = GameObject.Find("MusicPlayer");
        songFolder = musicPlayer.GetComponent<AudioSource>().clip.name;
        kickSpawnTempo = LoadBeatsFromJson();
        StartCoroutine(nameof(SpawnKickBullets));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }

    private List<float> LoadBeatsFromJson()
    {
        string filename = $"Kicks - {musicPlayer.GetComponent<AudioSource>().clip.name}.txt";
        string filePath = Path.Combine(directory, songFolder, filename);
        ClipData clip= new ClipData();
        string dataString;

        if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }
            dataString = reader.text;


            clip = JsonUtility.FromJson<ClipData>(dataString);
            return clip.times;
        }
        else
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                clip = JsonUtility.FromJson<ClipData>(json);

                return clip.times;
            }
            else
            {
                Debug.LogError($"No such file found: {filePath}");
            }
        }

        return new List<float>();
    }

    private IEnumerator SpawnKickBullets()
    {
        yield return new WaitForSeconds(kickSpawnTempo[0] - 0.1f);
        foreach (var spawn in spawners)
        {
            var bullet = (GameObject)Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        }

        for (int i = 1; i < kickSpawnTempo.Count; i++)
        {
            yield return new WaitForSeconds(kickSpawnTempo[i] - kickSpawnTempo[i - 1] - (0.00002f * i));
            foreach (var spawn in spawners)
            {
                var bullet = (GameObject)Instantiate(bulletPrefab, spawn.position, spawn.rotation);
            }
        }
    }
}
