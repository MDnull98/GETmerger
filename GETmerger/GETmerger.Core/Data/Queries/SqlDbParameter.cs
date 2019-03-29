using System.Collections;
using System.Collections.Generic;
using System.Data;
using Dapper;
using GETmerger.Core.Contracts.Data.Queries;

namespace GETmerger.Core.Core.Common.Data.Queries
{
    public class SqlDbParameter : ISqlDbParameter
    {
        #region Members

        private readonly List<IDbDataParameter> _parameters = new List<IDbDataParameter>();

        #endregion

        #region Methods
        public IEnumerator<IDbDataParameter> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Add(IDbDataParameter value)
        {
            _parameters.Add(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="identity"></param>
        void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            foreach (IDbDataParameter parameter in _parameters)
            command.Parameters.Add(parameter);
        }

        public override string ToString()
        {
            string parametersString = "";
            foreach (IDbDataParameter parameter in _parameters)
            {
                if (parameter != null)
                {
                    parametersString += parameter.ParameterName + ": " + (parameter.Value == null ? "null" : parameter.Value.ToString()) + " ";
                }
            }
            return parametersString;
        }
        #endregion
    }
}