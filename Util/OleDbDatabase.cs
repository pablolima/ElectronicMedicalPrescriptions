using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Util.Database
{
    class OleDbDatabase : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new OleDbConnection(connectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new OleDbCommand();
        }

        public override IDbConnection CreateOpenConnection()
        {
            OleDbConnection connection = (OleDbConnection)CreateConnection();
            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            OleDbCommand command = (OleDbCommand)CreateCommand();

            command.CommandText = commandText;
            command.Connection = (OleDbConnection)connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            OleDbCommand command = (OleDbCommand)CreateCommand();

            command.CommandText = procName;
            command.Connection = (OleDbConnection)connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new OleDbParameter(parameterName, parameterValue);
        }
    }
}
