using System;

using Xamarin.Forms;


namespace FlurrySample
{
	public class MainPage : ContentPage
	{
		public MainPage ()
		{
			var title = new Label {
				HeightRequest = 50,
				XAlign = TextAlignment.Center,
				Text = "Flurry Analitics & Xamarin Forms!"
			};

			var buttonEvent = new Button {
				HeightRequest = 50,
				WidthRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				Text = "Event without Parameters"
			};

			var buttonParameterEvent = new Button {
				HeightRequest = 50,
				WidthRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				Text = "Event with Parameters"
			};

			var buttonTimedEvent1 = new Button {
				HeightRequest = 50,
				WidthRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				Text = "Timed Event - Sample 1"
			};

			var buttonTimedEvent2 = new Button {
				HeightRequest = 50,
				WidthRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				Text = "Timed Event - Sample 2"
			};

			var buttonTimedEvent3 = new Button {
				HeightRequest = 50,
				WidthRequest = 200,
				HorizontalOptions = LayoutOptions.Center,
				Text = "Timed Event - Sample 3"
			};
			
			Content = new StackLayout {
				Padding = new Thickness(0, 50, 0, 0),
				Children = {
					title,
					buttonEvent,
					buttonParameterEvent,
					buttonTimedEvent1,
					buttonTimedEvent2,
					buttonTimedEvent3
				}
			};

			buttonEvent.SetBinding (Button.CommandProperty, new Binding (MainViewModel.EventCommandPropertyName));
			buttonParameterEvent.SetBinding (Button.CommandProperty, new Binding (MainViewModel.ParameterEventCommandPropertyName));
			buttonTimedEvent1.SetBinding (Button.CommandProperty, new Binding (MainViewModel.TimedEvent1CommandPropertyName));
			buttonTimedEvent2.SetBinding (Button.CommandProperty, new Binding (MainViewModel.TimedEvent2CommandPropertyName));
			buttonTimedEvent3.SetBinding (Button.CommandProperty, new Binding (MainViewModel.TimedEvent3CommandPropertyName));
		}
	}
}


