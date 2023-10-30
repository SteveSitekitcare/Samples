using Microsoft.Extensions.Logging;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Crashlytics;
using Plugin.Firebase.CloudMessaging;
#if IOS
using Plugin.Firebase.Bundled.Platforms.iOS;
#else
using Plugin.Firebase.Bundled.Platforms.Android;
#endif

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddSingleton<CalendarView>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MessagesView>();

            builder
                .UseMauiApp<App>()
                .RegisterFirebaseServices()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events => {
#if IOS
            events.AddiOS(iOS => iOS.FinishedLaunching((app, launchOptions) => {
                CrossFirebase.Initialize(CreateCrossFirebaseSettings());
                FirebaseCloudMessagingImplementation.Initialize();
                return false;
            }));
#else
                events.AddAndroid(android => android.OnCreate((activity, _) =>
                    CrossFirebase.Initialize(activity, CreateCrossFirebaseSettings())));
#endif

                CrossFirebaseCloudMessaging.Current.NotificationTapped += (sender, e) =>
                {
                    var messageType = e.Notification.Data["Type"];
                    if (messageType == "Message")
                    {
                        Shell.Current.GoToAsync(nameof(MessagesView));
                    }
                    else if (messageType == "Calendar")
                    {
                        Shell.Current.GoToAsync(nameof(CalendarView));
                    }
                };
            });

            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            return builder;
        }

        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(
                isAuthEnabled: true,
                isCloudMessagingEnabled: true);
        }
    }
}