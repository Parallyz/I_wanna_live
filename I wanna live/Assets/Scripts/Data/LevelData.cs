
using System;

public class LevelData
{
    public int levelNumber;
    public DateTime oneStarTime;
    public DateTime twoStarTime;
    public DateTime threeStarTime;

    public LevelData(int _levelNumber, DateTime _oneStarTime, DateTime _twoStarTime, DateTime _threeStarTime)
    {
        levelNumber = _levelNumber;
        oneStarTime = _oneStarTime;
        twoStarTime = _twoStarTime;
        threeStarTime = _threeStarTime;

    }

}
