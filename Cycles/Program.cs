var random = new Random();
int[] player1 = new[] { random.Next(100), random.Next(100), random.Next(100), random.Next(100) };
int[] player2 = new[] { random.Next(100), random.Next(100), random.Next(100), random.Next(100) };

int scorePlayer1 = 0;
int scorePlayer2 = 0;

for (int i = 0; i < player1.Length; i++)
{
    Console.WriteLine($"Round {i + 1}: Player 1 plays {player1[i]}, Player 2 plays {player2[i]}");
    if (player1[i] > player2[i])
    {
        scorePlayer1++;
    }
    else if (player1[i] < player2[i])
    {
        scorePlayer2++;
    }
}
if (scorePlayer1 > scorePlayer2)
{
    Console.WriteLine("Player 1 wins with score: " + scorePlayer1 + " to " + scorePlayer2);
}
else if (scorePlayer1 < scorePlayer2)
{
    Console.WriteLine("Player 2 wins with score: " + scorePlayer2 + " to " + scorePlayer1);
}
else
{
    Console.WriteLine("It's a tie with score: " + scorePlayer1 + " to " + scorePlayer2);
}