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

			Guesses.Add(new ColorGuess("beefed"));
			Guesses.Add(new ColorGuess("beeded"));
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
		void Guess()
		{
			// if correct, then go to game over (DidWin=true)

			// else if this is the 6th guess (and it's wrong)
			// then go to game over (DidWin=false)


			// Add this guess to the Guesses
			Guesses.Add(new ColorGuess(CurrentGuess));

		}


	}
}

