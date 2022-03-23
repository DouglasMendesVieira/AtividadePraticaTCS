using AtividadePraticaTCS.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using AtividadePraticaTCS.Models.ViewModels;

namespace AtividadePraticaTCS.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private static string connString = "Server=localhost;Database=tcs;Uid=root;Pwd=douglas9k4knj";
        private int executionCount = 0;
        private readonly ILogger<TimedHostedService> _logger;
        public static Timer _timer = null;

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, Timeout.Infinite, Timeout.Infinite);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            MySqlDataReader data_reader;

            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            List<Status> StatusExistentes = new List<Status>();
            List<int> MachinesExistentes = new List<int>();

            try
            {
                connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = ("SELECT Id,Code FROM status");
                data_reader = command.ExecuteReader();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        StatusExistentes.Add(new Status((int)data_reader.GetValue(0), (string)data_reader.GetValue(1), null));
                    }
                    data_reader.Close();
                }

                command.CommandText = ("SELECT Id FROM machine");
                data_reader = command.ExecuteReader();
                if (data_reader.HasRows)
                {
                    while (data_reader.Read())
                    {
                        MachinesExistentes.Add((int)data_reader.GetValue(0));
                    }
                    data_reader.Close();
                }

                for (int i = 0; i < MachinesExistentes.Count; i++)
                {
                    Random rand = new Random();
                    Status resultado = StatusExistentes[rand.Next(StatusExistentes.Count)];
                    string update = "UPDATE machine SET StatusId=@StatusId WHERE Id=@Id";
                    command.CommandText = update;
                    command.Parameters.AddWithValue("@StatusId", resultado.Id);
                    command.Parameters.AddWithValue("@Id", MachinesExistentes[i]);
                    command.Connection = connection;
                    command.ExecuteNonQuery();

                    string insert = "INSERT INTO statusevent(Date, CodeStatus, MachineId) VALUES(@Date, @CodeStatus, @MachineId) ";
                    command.CommandText = insert;
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.AddWithValue("@CodeStatus", resultado.Code);
                    command.Parameters.AddWithValue("@MachineId", MachinesExistentes[i]);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
