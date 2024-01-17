using UnityEngine;

[System.Serializable]
public class SubWave
{
    public GameObject enemy;
    public int count;
}

[System.Serializable]
public class Wave
{
    public SubWave[] subwaves;
    public float rate;

    public int GetTotal()
    {
        var i = 0;
        foreach(var sw in this.subwaves)
        {
            i += sw.count;
        }
        return i;
    }
}
