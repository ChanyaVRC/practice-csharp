using Library.InheritClass;

namespace Implementation;

public class InheritClass
{
    public static bool IsHuman(Animal animal)
    {
        return animal.Species == "Human";
    }

    public class Cat(string name) : Animal(name)
    {
        public override string ConvertToCry(string word)
        {
            return word + "にゃー";
        }
    }

    public class Dog(string name) : Animal(name)
    {
        public override string ConvertToCry(string word)
        {
            return word + "ワン";
        }
    }

    public class Human(string firstName, string lastName) : Animal(GetName(firstName, lastName))
    {
        private static string GetName(string firstName, string lastName) => $"{firstName} {lastName}";

        private string _lastName = lastName;

        public string FirstName { get; } = firstName;

        public string LastName
        {
            get => _lastName;
            private set
            {
                _lastName = value;
                Name = GetName(FirstName, LastName);
            }
        }

        // 結婚する関数を作る
        public void MarryTo(Human human)
        {
            if (human.GeneticSex == GeneticSex)
            {
                throw new NotSupportedException("同性同士の結婚はサポートされていません。");
            }

            if (human.GeneticSex == GeneticSex.Male)
            {
                LastName = human.LastName;
            }
            if (GeneticSex == GeneticSex.Male)
            {
                human.LastName = LastName;
            }
        }

        public override string ConvertToCry(string word)
        {
            return word + "です";
        }
    }
 }

