namespace Mapidemic;

/// <summary>
/// The HomePage UI for the App
/// </summary>
public partial class HomePage : FlyoutPage
{
	private NavigationPage viewport;
	private const string cdcLink = "https://www.cdc.gov/";

	/// <summary>
	/// The default constructor for the HomePage
	/// </summary>
	public HomePage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// A function that prepares the viewport after
	/// it has been loaded with a ContentPage
	/// </summary>
	private void PrepareViewport()
	{
		viewport.BarTextColor = Color.FromArgb("#FFFFFF");
		viewport.BarBackgroundColor = Color.FromArgb("#0074C0");
		ViewPort.PushAsync(viewport);
		IsPresented = false;
	}

	/// <summary>
	/// A function that displays the about us page
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	public void AuButton_Clicked(object sender, EventArgs args)
	{
		viewport = new NavigationPage(new AboutUs());
		PrepareViewport();
	}

	/// <summary>
	/// A function that displays the who we are page
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	public void WwdButton_Clicked(object sender, EventArgs args)
	{
		viewport = new NavigationPage(new WhatWeDo());
		PrepareViewport();
	}

	/// <summary>
	/// A function that displays the contact information page
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	public void CiButton_Clicked(object sender, EventArgs args)
	{
		viewport = new NavigationPage(new ContactInformation());
		PrepareViewport();
	}

	/// <summary>
	/// A function that directs the user to the
	/// website of the CDC
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	public async void CdcButton_Clicked(object sender, EventArgs args)
	{
		await Launcher.Default.OpenAsync(new Uri(cdcLink));
	}
}