using AndroidX.Lifecycle;

namespace HeaderIssue
{
    public partial class MainPage : Header
    {
        private readonly ViewModel viewModel;
        int count = 0;

        public MainPage(ViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            this.viewModel = viewModel;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            var model = new Model { Name = count.ToString(), Status = count % 2 == 0 };
            viewModel.MyModel.Add(model);            
        }
    }
}