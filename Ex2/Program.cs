using System;
using System.Linq;

namespace Ex2
{
    class Program {
        static void Main(string[] args) {
            Player p = new Player(name: "molenda",
                password: "AbCd#123!");
            p.AddScore(22);
            p.AddScore(41);
            Console.WriteLine(p);
            p.Name = "kmol9";
            p.ChangePassword(oldPassword: "AbCd#123!",
                newPassword: "a123*!BC");
            Console.WriteLine(p.TryAddScore(32));
            Console.WriteLine(p);
        }
    }

    public class Player {
        private string _name;
        private string _password;
        private int _numberOfGames;
        private double _avg;

        public string Name {
            get => _name;
            set {
                value = value.Replace(" ", "").ToLower();
                value = value.Replace(" ", "").ToLower();
                if (string.IsNullOrEmpty(value) ||
                    value.Length < 0 ||
                    !value.All(a => char.IsDigit(a) || char.IsLetter(a)) ||
                    !char.IsLetter(value[0])) {
                    throw new ArgumentException("Wrong name!");
                }

                _name = value;
            }
        }

        private string Password {
            get => _password;
            set {
                if (value.Length < 8 ||
                    value.Length > 16 ||
                    !value.Any(a => char.IsPunctuation(a)) ||
                    !value.Any(a => char.IsDigit(a)) ||
                    !value.Any(a => char.IsLetter(a)) ||
                    !value.Any(a => char.IsUpper(a)) ||
                    value != value.Trim()) {
                    throw new ArgumentException("Wrong password!");
                }
            }
        }

        public int BestScore { get; set; }
        public int LastScore { get; set; }

        public double AvgScore {
            get => Math.Round(_avg, 1);
            set => _avg = value;
        }

        public Player(string name, string password) {
            Name = name;
            Password = password;
            BestScore = 0;
            LastScore = 0;
            AvgScore = 0;
            _numberOfGames = 0;
        }

        public void AddScore(int currentScore) {
            if (currentScore < 0 || currentScore > 100) {
                throw new ArgumentOutOfRangeException("Wrong value!");
            }

            if (currentScore > BestScore) {
                BestScore = currentScore;
            }

            LastScore = currentScore;
            AvgScore = ((AvgScore * _numberOfGames) + currentScore) / (_numberOfGames + 1);
            _numberOfGames++;
        }

        public bool TryAddScore(int currentScore) {
            try {
                AddScore(currentScore);
                return true;
            }
            catch (ArgumentOutOfRangeException) {
                return false;
            }
        }

        public bool ChangePassword(string oldPassword, string newPassword) {
            if (oldPassword == Password) {
                Password = newPassword;
                return true;
            }

            return false;
        }

        public bool VerifyPassword(string password) {
            if (password == Password) {
                return true;
            }

            return false;
        }

        public override string ToString() {
            return$"Name: {Name}, Score: last={LastScore}, best={BestScore}, avg={AvgScore}";
        }
    }
}