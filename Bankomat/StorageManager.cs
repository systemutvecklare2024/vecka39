using System.Text.Json;

namespace Bankomat
{
    internal class StorageManager
    {
        const string DEFAULT_PATH = "accounts.json";
        const string TEMP_PATH = "accounts.temp.json";
        public string Path { get; private set; }
        public StorageManager(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Path = DEFAULT_PATH;
                return;
            }

            Path = path;
        }

        public void Save(List<BankAccount> accounts)
        {
            List<BankAccountDto> dtos = new List<BankAccountDto>();
            foreach (BankAccount account in accounts)
            {
                dtos.Add(BankAccountDto.FromBankAccount(account));
            }

            try
            {
                var json = JsonSerializer.Serialize(dtos);

                File.WriteAllText(TEMP_PATH, json);
                File.Copy(TEMP_PATH, Path, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<BankAccount> Load()
        {
            var accounts = new List<BankAccount>();

            try
            {
                var fileContent = File.ReadAllText(Path);
                var dtos = JsonSerializer.Deserialize<List<BankAccountDto>>(fileContent) ?? [];

                foreach (var dto in dtos)
                {
                    accounts.Add(dto.ToBankAccount());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No database was found.");
                Console.WriteLine("A new database will be created when exiting the program.");
            }
            catch (Exception)
            {
                throw;
            }

            return accounts;
        }
    }
}
