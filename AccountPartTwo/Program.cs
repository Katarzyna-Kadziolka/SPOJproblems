using System;

namespace AccountPartTwo {
    class Program {
        static void Main(string[] args) {

            var john = new AccountPlus("John", initialBalance: 100.0m);
            Console.WriteLine(john);

            john.Withdrawal(-50.0m);
            Console.WriteLine(john);

            john.Withdrawal(50.0m);
            Console.WriteLine(john);

            john.Withdrawal(100.0m);
            Console.WriteLine(john);

            john.Withdrawal(10.0m);
            Console.WriteLine(john);

            john.Deposit(80.0m);
            Console.WriteLine(john);

            john.Deposit(-80.0m);
            Console.WriteLine(john);
        }
    }

    public interface IAccount {
        // nazwa klienta, bez spacji przed i po
        // readonly - modyfikowalna wyłącznie w konstruktorze
        string Name { get; }

        // bilans, aktualny stan środków, podawany w zaokrągleniu do 2 miejsc po przecinku
        decimal Balance { get; }

        // czy konto jest zablokowane
        bool IsBlocked { get; }
        void Block(); // zablokowanie konta
        void Unblock(); // odblokowanie konta

        // wpłata, dla kwoty ujemnej - zignorowana (false)
        // jeśli konto zablokowane - zignorowana (false)
        // true jeśli wykonano i nastąpiła zmiana salda
        bool Deposit(decimal amount);

        // wypłata, dla kwoty ujemnej - zignorowana (false)
        // jeśli konto zablokowane - zignorowana (false)
        // jeśli jest niewystarczająca ilość środków - zignorowana (false)
        // true jeśli wykonano i nastąpiła zmiana salda   
        bool Withdrawal(decimal amount);
    }

    public interface IAccountWithLimit : IAccount {
        // przyznany limit debetowy
        // mozliwość zmiany, jeśli konto nie jest zablokowane
        decimal OneTimeDebetLimit { get; set; }

        // dostępne środki, z uwzględnieniem limitu
        decimal AvaibleFounds { get; }
    }

    public class Account : IAccount {
        protected const int PRECISION = 4;

        public string Name { get; }
        public decimal Balance { get; private set; }


        public bool IsBlocked { get; private set; } = false;
        public void Block() => IsBlocked = true;
        public void Unblock() => IsBlocked = false;

        public Account(string name, decimal initialBalance = 0) {
            if (name == null || initialBalance < 0)
                throw new ArgumentOutOfRangeException();
            Name = name.Trim();
            if (Name.Length < 3)
                throw new ArgumentException();
            Balance = Math.Round(initialBalance, PRECISION);
        }

        public bool Deposit(decimal amount) {
            if (amount <= 0 || IsBlocked) return false;

            Balance = Math.Round(Balance += amount, PRECISION);
            return true;
        }

        public bool Withdrawal(decimal amount) {
            if (amount <= 0 || IsBlocked || amount > Balance) return false;

            Balance = Math.Round(Balance -= amount, PRECISION);
            return true;
        }

        public override string ToString() =>
            IsBlocked
                ? $"Account name: {Name}, balance: {Balance:F2}, blocked"
                : $"Account name: {Name}, balance: {Balance:F2}";
    }

    public class AccountPlus : Account, IAccountWithLimit {
        private decimal _oneTimeDebetLimit;
        public new bool IsBlocked { get; set; }

        public decimal OneTimeDebetLimit {
            get => Math.Round(_oneTimeDebetLimit, 4) ;
            set {
                if (value > 0 && !IsBlocked) {
                    AvaibleFounds = AvaibleFounds - _oneTimeDebetLimit;
                    _oneTimeDebetLimit = value;
                    AvaibleFounds = AvaibleFounds + value;
                }
            }
        }

        public decimal AvaibleFounds { get; set; }

        public AccountPlus(string name, decimal initialBalance = 0.00m, decimal initialLimit = 100.00m) : base(name,
            initialBalance) {
            if (initialLimit < 0) {
                initialLimit = 0.00m;
            }
            OneTimeDebetLimit = initialLimit;
            AvaibleFounds = initialBalance + initialLimit;
        }

        public new void Block() {
            IsBlocked = true;
        }

        public new void Unblock() {
            if (AvaibleFounds >= 0) {
                IsBlocked = false;
            }
        }

        public new bool Withdrawal(decimal amount) {
            if (amount <= 0 || IsBlocked || amount > AvaibleFounds) return false;

            AvaibleFounds = Math.Round(AvaibleFounds -= amount, PRECISION);
            if (AvaibleFounds - _oneTimeDebetLimit < 0) {
                IsBlocked = true;
            }

            base.Withdrawal(amount);

            return true;
        }

        public new bool Deposit(decimal amount) {
            if (amount <= 0 || IsBlocked) return false;

            AvaibleFounds = Math.Round(AvaibleFounds += amount, PRECISION);
            if (AvaibleFounds - _oneTimeDebetLimit > 0) {
                IsBlocked = false;
            }

            base.Deposit(amount);

            return true;
        }

        public override string ToString() =>
            IsBlocked
                ? $"Account name: {Name}, balance: {Balance:F2}, blocked, avaible founds: {AvaibleFounds:F}, limit: {OneTimeDebetLimit:F}"
                : $"Account name: {Name}, balance: {Balance:F2}, avaible founds: {AvaibleFounds:F}, limit: {OneTimeDebetLimit:F}";
    }
}