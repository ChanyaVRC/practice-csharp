namespace Implementation;

public class MakeClassIntroduction
{
    public class User
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        public User(string name)
        {
            _name = name;
        }
        public User() : this("unknown")
        {
            // empty
        }
        public void SetName(string name)
        {
            _name = name;
        }
    }
}
