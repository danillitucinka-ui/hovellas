using System;
using System.Collections.Generic;

public struct Vector3
{
    public float X, Y, Z;
    public Vector3(float x, float y, float z) { X = x; Y = y; Z = z; }
}

public class Evidence
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Found { get; set; }
    public Vector3 Position { get; set; } // 3D position

    public Evidence(string id, string name, string desc, Vector3 pos)
    {
        Id = id;
        Name = name;
        Description = desc;
        Found = false;
        Position = pos;
    }
}

public class EvidenceManager
{
    private List<Evidence> evidences;

    public EvidenceManager()
    {
        evidences = new List<Evidence>();
        InitializeEvidences();
    }

    private void InitializeEvidences()
    {
        // 20 evidences with positions
        evidences.Add(new Evidence("glass_fragment", "Glass Fragment", "Broken glass from lab.", new Vector3(0, 0, 0)));
        evidences.Add(new Evidence("security_log", "Security Log", "Access log.", new Vector3(1, 0, 0)));
        // Add 18 more
        for (int i = 2; i < 20; i++)
        {
            evidences.Add(new Evidence($"evidence_{i}", $"Evidence {i}", $"Description {i}", new Vector3(i, 0, 0)));
        }
    }

    public Evidence GetEvidence(string id)
    {
        return evidences.Find(e => e.Id == id);
    }

    public List<Evidence> GetAllEvidences()
    {
        return evidences;
    }

    public void MarkFound(string id)
    {
        var ev = GetEvidence(id);
        if (ev != null) ev.Found = true;
    }

    public int FoundCount()
    {
        return evidences.Count(e => e.Found);
    }

    public void UpdateSuspicion(SuspectManager suspectManager)
    {
        foreach (var suspect in suspectManager.GetAllSuspects())
        {
            suspect.SuspicionIndex = Math.Max(0, suspect.SuspicionIndex - FoundCount());
        }
    }
}