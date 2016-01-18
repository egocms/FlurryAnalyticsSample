
using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FlurrySample
{
	public class MainViewModel : BaseViewModel
	{
		public MainViewModel ()
		{
		}

		#region Prperties

		public const string EventCommandPropertyName = "EventCommand";
		Command _eventCommand;
		public Command EventCommand {
			get {
				return _eventCommand ?? (_eventCommand = new Command (LogEvent)); 
			}
		}		

		public const string ParameterEventCommandPropertyName = "ParameterEventCommand";
		Command _parameterEventCommand;
		public Command ParameterEventCommand {
			get {
				return _parameterEventCommand ?? (_parameterEventCommand = new Command (LogParameterEvent)); 
			}
		}

		public const string TimedEvent1CommandPropertyName = "TimedEvent1Command";
		Command _timedEvent1Command;
		public Command TimedEvent1Command {
			get {
				return _timedEvent1Command ?? (_timedEvent1Command = new Command (async () => await LogTimedEvent1 ())); 
			}
		}

		public const string TimedEvent2CommandPropertyName = "TimedEvent2Command";
		Command _timedEvent2Command;
		public Command TimedEvent2Command {
			get {
				return _timedEvent2Command ?? (_timedEvent2Command = new Command (async () => await LogTimedEvent2 ())); 
			}
		}

		public const string TimedEvent3CommandPropertyName = "TimedEvent3Command";
		Command _timedEvent3Command;
		public Command TimedEvent3Command {
			get {
				return _timedEvent3Command ?? (_timedEvent3Command = new Command (async () => await LogTimedEvent3 ())); 
			}
		}

		#endregion

		#region Actions

		void LogEvent ()
		{
			Flurry.Analytics.Portable.AnalyticsApi.LogEvent ("EventWithoutParameters");
		}

		void LogParameterEvent ()
		{
			var analiticsParam = new System.Collections.Generic.Dictionary<string, string> {
				{ "parameter", "test" }
			};
			Flurry.Analytics.Portable.AnalyticsApi.LogEvent ("EventWithParameters", analiticsParam);
		}

		async Task LogTimedEvent1 ()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			using (Flurry.Analytics.Portable.AnalyticsApi.LogTimedEvent("TimedEvent1")) {
				await Task.Delay(new TimeSpan(0,0,3));
			}

			IsBusy = false;
		}

		async Task LogTimedEvent2 ()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			Flurry.Analytics.Portable.AnalyticsApi.LogEvent ("TimedEvent2", true);
			await Task.Delay (new TimeSpan (0, 0, 3));
			Flurry.Analytics.Portable.AnalyticsApi.EndTimedEvent ("TimedEvent2");

			IsBusy = false;
		}

		async Task LogTimedEvent3 ()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			//	 initial data
			var parameters = new System.Collections.Generic.Dictionary<string, string> {
				{ "parameter1", "1" },
				{ "parameter2", "2" }
			};
				
			// start logging the event
			using (var timed = Flurry.Analytics.Portable.AnalyticsApi.LogTimedEvent ("TimedEvent3", parameters)) {
				await Task.Delay (new TimeSpan (0, 0, 3));
				
				// update the parameters
				timed.Parameters ["parameter1"] = "3";
				timed.Parameters ["parameter2"] = "4";
			}

			IsBusy = false;
		}

		#endregion
	}



}

