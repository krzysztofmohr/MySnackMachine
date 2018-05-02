namespace DddInPractice.Logic.UI
{
    public partial class App
    {
        public App()
        {
            SessionFactory.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true");
        }
    }
}
