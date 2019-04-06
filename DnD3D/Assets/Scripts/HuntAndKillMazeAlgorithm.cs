using System.Collections;
using UnityEngine;

public class HuntAndKillMazeAlgorithm : MazeAlgorithm {
	private int currentColumn = 0;
	private int currentRow = 0;
	private bool courseComplete = false;
	public HuntAndKillMazeAlgorithm (Tile[, ] tiles) : base (tiles) { }
	public override void CreateMaze () {
		HuntAndKill ();
	}
	private void HuntAndKill () {
		tiles[currentColumn, currentRow].SetVisited (true);

		while (!courseComplete) {
			Kill (); // Will run until it hits a dead end.
			Hunt (); // Finds the next unvisited cell with an adjacent visited cell. If it can't find any, it sets courseComplete to true.
		}
	}
	private void Kill () {
		while (RouteStillAvailable (currentColumn, currentRow)) {
			int direction = Random.Range (1, 5);
			if (direction == 1 && CellIsAvailable (currentColumn, currentRow + 1)) {
				// North
				DestroyWallIfItExists (tiles[currentColumn, currentRow].GetNorthWall (), currentColumn, currentRow);
				DestroyWallIfItExists (tiles[currentColumn, currentRow + 1].GetSouthWall (), currentColumn, currentRow + 1);
				currentRow++;
			} else if (direction == 2 && CellIsAvailable (currentColumn, currentRow - 1)) {
				// South
				DestroyWallIfItExists (tiles[currentColumn, currentRow].GetSouthWall (), currentColumn, currentRow);
				DestroyWallIfItExists (tiles[currentColumn, currentRow - 1].GetNorthWall (), currentColumn, currentRow - 1);
				currentRow--;
			} else if (direction == 3 && CellIsAvailable (currentColumn + 1, currentRow)) {
				// east
				DestroyWallIfItExists (tiles[currentColumn, currentRow].GetEastWall (), currentColumn, currentRow);
				DestroyWallIfItExists (tiles[currentColumn + 1, currentRow].GetWestWall (), currentColumn + 1, currentRow);
				currentColumn++;
			} else if (direction == 4 && CellIsAvailable (currentColumn - 1, currentRow)) {
				// west
				DestroyWallIfItExists (tiles[currentColumn, currentRow].GetWestWall (), currentColumn, currentRow);
				DestroyWallIfItExists (tiles[currentColumn - 1, currentRow].GetEastWall (), currentColumn - 1, currentRow);
				currentColumn--;
			}
			tiles[currentColumn, currentRow].SetVisited (true);
		}
	}
	private void Hunt () {
		courseComplete = true; // Set it to this, and see if we can prove otherwise below!

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				if (!tiles[c, r].GetVisited () && CellHasAnAdjacentVisitedCell (c, r)) {
					courseComplete = false; // Yep, we found something so definitely do another Kill cycle.
					currentColumn = c;
					currentRow = r;
					DestroyAdjacentWall (currentColumn, currentRow);
					tiles[currentColumn, currentRow].SetVisited (true);
					return; // Exit the function
				}
			}
		}
	}
	private bool RouteStillAvailable (int column, int row) {
		int availableRoutes = 0;

		if (column > 0 && !tiles[column - 1, row].GetVisited ()) {
			availableRoutes++;
		}

		if (column < mazeColumns - 1 && !tiles[column + 1, row].GetVisited ()) {
			availableRoutes++;
		}

		if (row > 0 && !tiles[column, row - 1].GetVisited ()) {
			availableRoutes++;
		}

		if (row < mazeRows - 1 && !tiles[column, row + 1].GetVisited ()) {
			availableRoutes++;
		}

		return availableRoutes > 0;
	}

	private bool CellIsAvailable (int column, int row) {
		if (row >= 0 && row < mazeRows && column >= 0 && column < mazeColumns && !tiles[column, row].GetVisited ()) {
			return true;
		} else {
			return false;
		}
	}
	private void DestroyWallIfItExists (GameObject wall, int c, int r) {
		if (wall != null) {
			tiles[c, r].AddDoor (wall);
			GameObject.Destroy (wall);
		} 
	}
	private bool CellHasAnAdjacentVisitedCell (int column, int row) {
		int visitedCells = 0;

		// Look 1 row up (north)
		if (row < (mazeRows - 2) && tiles[column, row + 1].GetVisited ()) {
			visitedCells++;
		}

		// Look one row down (south) if we're the second-to-last row (or less)
		if (row > 0 && tiles[column, row - 1].GetVisited ()) {
			visitedCells++;
		}

		// Look one row left (west) if we're column 1 or greater
		if (column > 0 && tiles[column - 1, row].GetVisited ()) {
			visitedCells++;
		}

		// Look one row right (east) if we're the second-to-last column (or less)
		if (column < (mazeColumns - 2) && tiles[column + 1, row].GetVisited ()) {
			visitedCells++;
		}

		// return true if there are any adjacent visited cells to this one
		return visitedCells > 0;
	}
	private void DestroyAdjacentWall (int column, int row) {
		bool wallDestroyed = false;
		while (!wallDestroyed) {
			int direction = Random.Range (1, 5);
			//South
			if (direction == 1 && row > 0 && tiles[column, row - 1].GetVisited ()) {
				DestroyWallIfItExists (tiles[column, row].GetSouthWall (), currentColumn, currentRow);
				DestroyWallIfItExists (tiles[column, row - 1].GetNorthWall (), currentColumn, currentRow - 1);
				wallDestroyed = true;
			} //North
			else if (direction == 2 && row < mazeRows - 1 && tiles[column, row + 1].GetVisited ()) {
				DestroyWallIfItExists (tiles[column, row].GetNorthWall (), currentColumn, currentRow);
				DestroyWallIfItExists (tiles[column, row + 1].GetSouthWall (), currentColumn, currentRow + 1);
				wallDestroyed = true;
			} //West
			else if (direction == 3 && column > 0 && tiles[column - 1, row].GetVisited ()) {
				DestroyWallIfItExists (tiles[column, row].GetWestWall (), currentColumn, currentRow);
				DestroyWallIfItExists (tiles[column - 1, row].GetEastWall (), currentColumn - 1, currentRow);
				wallDestroyed = true;
			} //East
			else if (direction == 4 && column < mazeColumns - 1 && tiles[column + 1, row].GetVisited ()) {
				DestroyWallIfItExists (tiles[column, row].GetEastWall (), currentColumn, currentRow);
				DestroyWallIfItExists (tiles[column + 1, row].GetWestWall (), currentColumn + 1, currentRow);
				wallDestroyed = true;
			}
		}
	}
}