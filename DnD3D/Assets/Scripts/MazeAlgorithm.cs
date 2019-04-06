using System.Collections;
using UnityEngine;

public abstract class MazeAlgorithm {
	protected Tile[, ] tiles;
	protected int mazeRows, mazeColumns;

	protected MazeAlgorithm (Tile[, ] tiles) : base () {
		this.tiles = tiles;
		mazeColumns = tiles.GetLength (0);
		mazeRows = tiles.GetLength (1);
	}

	public abstract void CreateMaze ();
}