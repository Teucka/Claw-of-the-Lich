using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spell : MonoBehaviour
{
    public Vector2 castLocation;
    public int spellID;
    public string spellName;
    private GameObject parent;

    public void destroy()
    {
        Destroy(gameObject);
    }

    public Vector2 getCurrentMousePos()
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        return hit.point;
    }

    public void setParent(GameObject g)
    {
        parent = g;
    }

    public GameObject getParent()
    {
        return parent;
    }

    public List<GameObject> getUnitsAtPoint(Vector2 point, float radius)
    {
        List<GameObject> mobs = new List<GameObject>();

        foreach (GameObject g in UnitList.getHostiles())
        {
            if (Ellipse.isometricDistance(point, g.transform.position) < radius)
            {
                mobs.Add(g);
            }
        }

        return mobs;
    }
}
