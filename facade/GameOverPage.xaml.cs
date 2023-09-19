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
			if(didWin)
			{
				ResultLabel.Text = "You Won!";
			}
			else
			{
				ResultLabel.Text = "You Lost!";
			}
		}
	}

	private void Restart_Button_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage());
	}

    //private string result;
    //public string Result {
    //	get => result;
    //	set
    //	{
    //		result = value;
    //           ResultLabel.Text = "You " + result;
    //       }
    //}

    public GameOverPage()
	{
		InitializeComponent();
	}
}
