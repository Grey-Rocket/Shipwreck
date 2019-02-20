using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RealTimePath : MonoBehaviour {

    public Tile nLTile;
    public Tile rLTile;
    public Tile nRTile;
    public Tile rRTile;

    public Tile arrow;
    public Tile horizontal;
    public Tile vertical;

    public Transform player;

    public Tilemap arrowTiles;

    private Vector3Int startPos;
    private Vector3Int holder;
    private bool clicked;

    // Use this for initialization
    void Start () {
        Debug.Log(player.position);
        //Debug.Log(new Vector3Int(player.position.x, player.position.y, 0));
        startPos = new Vector3Int(0, 0, 0);
        holder = new Vector3Int(0, 0, 0);
        clicked = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3Int temp = new Vector3Int(Mathf.FloorToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x),
          Mathf.FloorToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y), 0);
        Debug.Log(temp);
        if (Input.GetMouseButtonDown(0))
        {
            if (!clicked && temp == startPos)
            {
                clicked = true;
            }
            else if (clicked)
            {
                //playerTiles.SetTile(startPos, null);
                arrowTiles.ClearAllTiles();
                //playerTiles.SetTile(temp, player);

                clicked = false;

                startPos = temp;

            }
        }

        if (clicked && temp == startPos)
        {
            arrowTiles.ClearAllTiles();
        }
        else if (clicked && holder != temp)
        {
            arrowTiles.ClearAllTiles();
            holder = temp;

            DrawLine(temp);
        }
    }

    //this draws the line
    void DrawLine(Vector3Int destination)
    {
        int x = startPos.x;
        int y = startPos.y;

        //here it generates horizontal lines
        if (destination.x > x)
        {
            x++;

            while (x < destination.x)
            {
                arrowTiles.SetTile(new Vector3Int(x, y, 0), horizontal);
                x++;
            }
        }
        else if (destination.x < x)
        {
            x--;

            while (x > destination.x)
            {
                arrowTiles.SetTile(new Vector3Int(x, y, 0), horizontal);
                x--;
            }
        }

        if (destination.y != startPos.y && destination.x != startPos.x)
        {
            AddCorner(y, x, destination.y);
        }

        //here it generates vertical lines
        if (destination.y > y)
        {
            y++;

            while (y < destination.y)
            {
                arrowTiles.SetTile(new Vector3Int(x, y, 0), vertical);
                y++;
            }
        }
        else if (destination.y < y)
        {
            y--;

            while (y > destination.y)
            {
                arrowTiles.SetTile(new Vector3Int(x, y, 0), vertical);
                y--;
            }
        }

        arrowTiles.SetTile(new Vector3Int(x, y, 0), arrow);

        float rotiramo;

        if (destination.y > startPos.y)
        {
            rotiramo = 90f;
        }
        else if (destination.y < startPos.y)
        {
            rotiramo = 270f;
        }
        else
        {
            if (destination.x > startPos.x)
            {
                rotiramo = 0f;
            }
            else
            {
                rotiramo = 180f;
            }
        }

        //rotates by 90 degrees
        //Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, rotiramo), Vector3.one);

        arrowTiles.SetTransformMatrix(new Vector3Int(x, y, 0), matrix);
    }

    //adds a corner
    void AddCorner(int y, int x, int endy)
    {
        if (x > startPos.x)
        {
            if (endy > startPos.y)
            {
                arrowTiles.SetTile(new Vector3Int(x, y, 0), rLTile);
            }

            else
            {
                arrowTiles.SetTile(new Vector3Int(x, y, 0), rRTile);
            }
        }

        else
        {
            if (endy > startPos.y)
            {
                arrowTiles.SetTile(new Vector3Int(x, y, 0), nLTile);
            }

            else
            {
                arrowTiles.SetTile(new Vector3Int(x, y, 0), nRTile);
            }
        }
    }
}
