using System;


namespace Dojodachi.Models

{

namespace Dojodachi.Models
{
    public class Monster
    {
        public string Action {get;set;}
        public int Energy {get;set;}
        public int Fullness {get;set;}
        public int Happiness {get;set;}
        public int Meals {get;set;}
        public int Status {get;set;} //1 = GameOn, 0 = Dead, 2 = Win

        //Dojodachi Constructor
        public Monster()
        {
            //A Dojodachi should start with 50 Energy, 20 Fullness, 20 Happiness, and 3 Meals
            Action = "Use the buttons below to have your Dojodachi Feed, Play, Work, or Sleep";
            Energy = 50;
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Status = 1;
        }

        //Feed Method
        public void Feed()
        {
            //Feeding your Dojodachi costs 1 Meal and gains a random amount of Fullness between 5 and 10
            //Every time you play with or feed your Dojodachi there should be a 25% chance that it won't like it.
            //Energy or Meals will still decrease, but Happiness and Fullness won't change.
            if (Meals > 0)
            {
                Random rand = new Random();
                int chance = rand.Next(4);
                Meals--;
                if (chance == 2)
                {
                    Action = $"You tried to feed your Monster but it didn't like it! Fullness +0, Meals -1";
                }
                else
                {
                    int tempFull = rand.Next(5,11);
                    Fullness += tempFull;
                    Action = $"You fed your Monster! Fullness +{tempFull}, Meals -1";
                }
            }
            else
            {
                Action = $"You cannot feed your Monster because there are no Meals to feed it";
            }
            CheckStatus();
        }

        //Play Method
        public void Play()
        {
            //Playing with your Dojodachi costs 5 Energy and gains a random amount of Happiness between 5 and 10
            //Every time you play with or feed your Dojodachi there should be a 25% chance that it won't like it.
            //Energy or Meals will still decrease, but Happiness and Fullness won't change.
            if (Energy > 4)
            {
                Random rand = new Random();
                int chance = rand.Next(4);
                Energy -= 5;
                if (chance == 3)
                {
                    Action = $"You tried to play with your Monster but it didn't like it! Happiness +0, Energy -5";
                }
                else
                {
                    int tempHapp = rand.Next(5,11);
                    Happiness += tempHapp;
                    Action = $"You played with your Monster! Happiness +{tempHapp}, Energy -5";
                }
            }
            else
            {
                Action = $"You cannot play with your Monster because they do not have enough Energy";
            }
            CheckStatus();
        }

        //Work Method
        public void Work()
        {
            //Working costs 5 Energy and earns between 1 and 3 Meals
            if (Energy > 4)
            {
                Random rand = new Random();
                int tempMeals = rand.Next(1,4);
                Meals += tempMeals;
                Energy -= 5;
                Action = $"Your Monster worked! Meals +{tempMeals}, Energy -5";
            }
            else
            {
                Action = $"Your Monster cannot work because it do not have enough Energy";
            }
        }

        //Sleep Method
        public void Sleep()
        {
            //Sleeping earns 15 Energy and decreases Fullness and Happiness each by 5
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            Action = $"Your Monster went to sleep! Energy +15, Fullness -5, Happiness -5";
            CheckStatus();
        }

        public void CheckStatus()
        {
            //Check if Fullness and Happiness are both over 100
            //If they are the player has won
            if (Fullness >= 100 && Happiness >= 100)
            {
                Action = $"Congratulations! You won!";
                Status = 2;
            }

            //Check if the Fullness or Happiness ever drops to 0
            //If either one has, then the player has lost
            if (Fullness < 1 || Happiness < 1)
            {
                Action = $"Your Monster is Dead **   D. E. E. D.  ** Dead HAHA try again";
                Status = 0;
            }
        }
    }
}
}