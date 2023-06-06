public class Player
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Player(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void UpdateAge(int newAge)
    {
        Age = newAge;
    }
}

public class FootballTeam
{
    private List<Player> players;

    public FootballTeam()
    {
        players = new List<Player>();
    }

    public void AddPlayer(string name, int age)
    {
        players.Add(new Player(name, age));
    }

    public void RemovePlayer(string name)
    {
        var playerToRemove = players.Find(p => p.Name == name);
        if (playerToRemove != null)
            players.Remove(playerToRemove);
        else
            throw new ArgumentException("Player not found in the team.");
    }

    public void UpdatePlayerAge(string name, int newAge)
    {
        var playerToUpdate = players.Find(p => p.Name == name);
        if (playerToUpdate != null)
            playerToUpdate.UpdateAge(newAge);
        else
            throw new ArgumentException("Player not found in the team.");
    }

    public Player GetYoungestPlayer()
    {
        if (!players.Any())
            throw new InvalidOperationException("The team has no players.");

        return players.OrderBy(p => p.Age).First();
    }

    public void DisplayTeamInfo()
    {
        foreach (var player in players)
        {
            Console.WriteLine($"Player Name: {player.Name}, Age: {player.Age}");
        }
    }
}
