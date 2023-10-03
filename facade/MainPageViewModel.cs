using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace facade
{
	public partial class MainPageViewModel: ObservableObject 
	{
		[ObservableProperty]
		private string secretColor;

		[ObservableProperty]
		private string currentGuess;


		public ObservableCollection<ColorGuess> Guesses { get; set; }

		//public string SecretColor { get; set; }

		public MainPageViewModel()
		{
			secretColor = "FACADE";
			currentGuess = "";

			//call the constructor 
			Guesses = new ObservableCollection<ColorGuess>();


		}


		[RelayCommand]
		void AddLetter(string letter)
		{
			if( CurrentGuess.Length < 6)
			{
				CurrentGuess += letter;
			}
		}

		[RelayCommand]
        void deleteButton_Clicked()
        {
			if(CurrentGuess.Length >= 1)
			{
				CurrentGuess = CurrentGuess.Substring(0, CurrentGuess.Length -1 );
			}

        }

        [RelayCommand]
		void Guess()
		{
            GameOverPage gameOverPage = new GameOverPage();
/*
            if (string.IsNullOrWhiteSpace(CurrentGuess))
            {
				// Show a message box when CurrentGuess is empty
				
            }*/
            // if correct, then go to game over (DidWin=true)
            if (CurrentGuess == SecretColor)
			{
				gameOverPage.DidWin = true;
                Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={gameOverPage.DidWin}");
            }
			// else if this is the 6th guess (and it's wrong)
			else if(Guesses.Count == 5 && CurrentGuess != SecretColor)
			{
                gameOverPage.DidWin = false;
                Shell.Current.GoToAsync($"{nameof(GameOverPage)}?DidWin={gameOverPage.DidWin}");
            }
			// then go to game over (DidWin=false)
	
			if(CurrentGuess != "" && CurrentGuess.Length == 6)
			{
            // Add this guess to the Guesses
            Guesses.Add(new ColorGuess(CurrentGuess));
			CurrentGuess = "";
			}


			


		}


	}
}

