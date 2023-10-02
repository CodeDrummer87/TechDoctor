using Domain;
using Domain.ElectricValues;
using Domain.EmployeeData;
using Domain.LocomotiveData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace Data;

public partial class DocContext : DbContext
{
    private static string _connectionString = GetConnectionString();

    public DocContext()
    { }

    public DocContext(DbContextOptions<DocContext> options)
        : base(options)
    { }

    public bool GetThemeValue()
    {
        bool result = false;
        try
        {
            SqliteCommand command = GetConnection().CreateCommand();
            command.CommandText = "SELECT IsDarkTheme FROM ThemeValue WHERE Id = 1";

            OpenConnection();
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                result = reader.GetInt32(0) == 1 ? true : false;

            reader.Close();
        }
        catch (Exception)
        {
            //.:: Запись в логи об ошибке :::
        }

        CloseConnection();

        return result;
    }
    public async Task SetThemeValue(bool value)
    {
        await Task.Run(() =>
        {
            try
            {
                SqliteCommand command = GetConnection().CreateCommand();
                command.CommandText = "UPDATE ThemeValue SET IsDarkTheme = @value WHERE Id = 1";
                command.Parameters.Add("@value", SqliteType.Integer).Value = value ? 1 : 0;

                OpenConnection();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //.:: Запись в логи об ошибке :::
            }

            CloseConnection();
        });
    }


    public DbSet<LocomotiveType> LocomotiveTypes { get; set; }
    public DbSet<LocoSeries> LocoSeries { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Locomotive> Locomotives { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Measuring> Measurings { get; set; }
    public DbSet<MeasuringData> MeasuringsData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(_connectionString);


    #region .:: Прямое подключение к БД для выполнения нативных запросов с фильтрацией :::

    static SqliteConnection sqliteConnection = new(_connectionString);

    public static void OpenConnection()
    {
        if (sqliteConnection.State == System.Data.ConnectionState.Closed)
            sqliteConnection.Open();
    }

    public static void CloseConnection()
    {
        if (sqliteConnection.State == System.Data.ConnectionState.Open)
            sqliteConnection.Close();
    }

    public static SqliteConnection GetConnection() => sqliteConnection;

    #endregion

    private static string GetConnectionString()
    {
        string applicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var connectionString = $@"DataSource={applicationDataPath}\NPC\docStorage.db";

        return connectionString;
    }
}

