[System.Serializable]
public class PlayerData {
    private int _highscore;

    public int highscore {
        get => _highscore;
        set => _highscore = value;
    }

    public PlayerData(int highscore) {
        _highscore = highscore;
    }
}
