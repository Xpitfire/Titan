using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Core.Graph.Database
{
    public sealed class ConnectionPool : IDisposable
    {
        public const string ConncetionString = "bolt://localhost:7687";
        public const string User = "xpitfire";
        public const string Password = "xpitfire";

        private readonly IDriver _driver;

        static ConnectionPool()
        {
            Instance = new ConnectionPool();
        }

        private ConnectionPool()
        {
            _driver = GraphDatabase.Driver(ConncetionString, AuthTokens.Basic(User, Password));
        }

        public static ConnectionPool Instance { get; private set; }

        public void Execute(Action<ISession> cmd)
        {
            using (var session = _driver.Session())
            {
                cmd(session);
            }
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }

    }
}
