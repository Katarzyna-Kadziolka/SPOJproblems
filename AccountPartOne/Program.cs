using System;

namespace AccountPartOne {
	public class Program {
		static void Main() {
            try
            {
                var account = new Account(null, 100.0m);
                Console.WriteLine(account);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Name is null");
            }
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
		void Block();   // zablokowanie konta
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

	public class Account : IAccount {
		private decimal _balance;

		public string Name { get; }
		public decimal Balance {
			get => Math.Round(_balance, 4);
			set {
				if (value < 0) {
					throw new ArgumentOutOfRangeException();
				}
				else {
					_balance = value;
				}
			}
		}
		public bool IsBlocked { get; set; }
		
		public Account(string name, decimal balance = 0.00m) {
            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentOutOfRangeException();
            }
			name = name.Trim();
			if (name.Length < 3) {
				throw new ArgumentException();
			}
			else {
				Name = name;
			}
			Balance = balance;
			IsBlocked = false;
		}
		
		public void Block() {
			IsBlocked = true;
		}

		public void Unblock() {
			IsBlocked = false;
		}

		public bool Deposit(decimal amount) {
			if (IsBlocked || amount <= 0) {
				return false;
			}
			else {
				Balance = Math.Round(Balance + amount, 4);
				return true;
			}
		}

		public bool Withdrawal(decimal amount) {
			if (IsBlocked || amount <= 0 || amount > Balance) {
				return false;
			}
			else {
				Balance = Math.Round(Balance - amount, 4);
				return true;
			}
		}

		public override string ToString() {
			if (IsBlocked) {
				return $"Account name: {Name}, balance: {Math.Round(Balance, 2)}, blocked";
			}
			else {
				return $"Account name: {Name}, balance: {Math.Round(Balance, 2) }";
			}
		}
	}
}