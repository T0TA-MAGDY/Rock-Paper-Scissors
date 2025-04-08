using System;


namespace Rock_Paper_scissor

{

    public enum Choice { Rock = 1, Paper, Scissors}
    
    public class RPSGame
    {
        private readonly Random rnd = new Random(); 

        public (Choice computerChoice, string result) Playround(Choice userChoice)
        {
            //get random choice for computer
            Choice computerChoice = (Choice)rnd.Next(1, 4);

            // determine result

            string result = DetermineWinner(computerChoice, userChoice);
            return (computerChoice, result);
        }

        // determine winner
        public string DetermineWinner(Choice computerChoice, Choice userChoice)
        {
            if (computerChoice == userChoice)
                return "It's a tie!";
            switch (computerChoice)
            {
                case Choice.Rock:
                    return userChoice == Choice.Paper ? "Paper covers rock, you win!" : "Rock crushes scissors, you lose!";

                case Choice.Paper:
                    return userChoice == Choice.Scissors ? "Scissors cut Paper, you win!" : "Paper covers rock, you lose!";

                case Choice.Scissors:
                    return userChoice == Choice.Rock ? "Rock crusher scissors, you win!" : "Scissors cut paper, you lose!";

                default:
                    return "Invalid choice"; 

            }
        }

    }

}
