
namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(MessagesView), typeof(MessagesView));
            Routing.RegisterRoute(nameof(CalendarView), typeof(CalendarView));
        }
    }
}