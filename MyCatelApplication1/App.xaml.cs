namespace MyCatelApplication1
{
	using System.Windows;

	using Catel.ApiCop;
	using Catel.ApiCop.Listeners;
	using Catel.IoC;
	using Catel.Logging;
	using Catel.Reflection;
	using Catel.Windows;

	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static readonly ILog Log = LogManager.GetCurrentClassLogger();

		protected override void OnStartup(StartupEventArgs e)
		{
#if DEBUG
            LogManager.AddDebugListener();
#endif

			Log.Info("Starting application");

			// Want to improve performance? Uncomment the lines below. Note though that this will disable
			// some features. 
			//
			// For more information, see http://docs.catelproject.com/vnext/faq/performance-considerations/

			// Log.Info("Improving performance");
			// Catel.Windows.Controls.UserControl.DefaultCreateWarningAndErrorValidatorForViewModelValue = false;
			// Catel.Windows.Controls.UserControl.DefaultSkipSearchingForInfoBarMessageControlValue = true;

			// TODO: Register custom types in the ServiceLocator
			//Log.Info("Registering custom types");
			//var serviceLocator = ServiceLocator.Default;
			//serviceLocator.RegisterType<IMyInterface, IMyClass>();

			// To auto-forward styles, check out Orchestra (see https://github.com/wildgums/orchestra)
			// StyleHelper.CreateStyleForwardersForDefaultStyles();

			Log.Info("Calling base.OnStartup");

			base.OnStartup(e);
		}

		protected override void OnExit(ExitEventArgs e)
		{
			// Get advisory report in console
			ApiCopManager.AddListener(new ConsoleApiCopListener());
			ApiCopManager.WriteResults();

			base.OnExit(e);
		}
	}
}