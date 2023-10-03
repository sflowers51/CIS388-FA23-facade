namespace facade;

[QueryProperty("DidWin", "DidWin")]
public partial class GameOverPage : ContentPage
{
	private bool didWin;
	public bool DidWin
	{
		get => didWin;
		set
		{
			didWin = value;
            MainPageViewModel mainPageViewModel = new MainPageViewModel();

            revealColor.Text = mainPageViewModel.SecretColor;

            if (didWin)
			{
				ResultLabel.Text = "You Won!";
                ImageLable.Source = "happyface.png";
			}
			else
			{
				ResultLabel.Text = "You Lost!";
                ImageLable.Source = "frownyfacetransparent.png";
            }
		}
	}

	private void Restart_Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage());
	}

/*	private string result;
	public string Result
	{
		get => result;
		set
		{
			result = value;
			result.text = "you " + result;
		}
	}*/

	public GameOverPage()
	{
		InitializeComponent();
	}
}
