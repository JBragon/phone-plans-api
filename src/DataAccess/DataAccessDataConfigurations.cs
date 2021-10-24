using JBragon.DataAccess.Configurations;
using System.Collections.Generic;

namespace JBragon.DataAccess
{
    public class DataAccessDataConfigurations
    {
        public static DataAccessDataConfigurations Instance { get; private set; } = new DataAccessDataConfigurations();

        private DataAccessDataConfigurations()
        {
        }

        public HashSet<dynamic> Configurations()
        {
            var config = new HashSet<dynamic>()
            {
                new PhonePlanConfiguration(),
                new DDDConfiguration(),
                new PhonePlanTypeConfiguration(),
                new TelephoneOperatorConfiguration()
            };

            return config;
        }
    }
}
