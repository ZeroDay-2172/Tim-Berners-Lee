namespace Mapidemic;

public partial class App : Application
{
	private const string uiSettingsPath = "ui_settings.json";

	public App()
	{
		InitializeComponent();
	}

	/// <summary>
	/// A helper function that deletes the user's local
	/// ui_settings.json file for developer testing
	/// </summary>
	/// <param name="destinationPath"></param>
	private void ClearSettings(string destinationPath)
	{
		File.Delete(destinationPath);
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		string destinationPath = Path.Combine(FileSystem.AppDataDirectory, uiSettingsPath);

		/// this function is for testing the settings setup
		ClearSettings(destinationPath);
		/// comment out this function when not testing

		if (File.Exists(destinationPath))
		{
			string jsonSettings = File.ReadAllText(destinationPath);
			if (string.IsNullOrEmpty(jsonSettings))
			{
				CreateFile(destinationPath);
				return new Window(new AppShell());
			}
			else
			{
				return new Window(new HomePage());
			}
		}
		else
		{
			CreateFile(destinationPath);
			return new Window(new AppShell());
		}
	}

	/// <summary>
	/// A helper function that creates a new ui_settings.json
	/// file in the instance that the file is not present or
	/// has been emptied
	/// </summary>
	/// <param name="destinationPath"></param>
	private void CreateFile(string destinationPath)
	{
		try
		{
			var input = FileSystem.OpenAppPackageFileAsync(uiSettingsPath);
			var output = File.Create(destinationPath);
			input.Result.CopyToAsync(output);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}
}