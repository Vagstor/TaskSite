using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(1)]
    public class CreateTSScheme_01 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE SCHEMA tasksite
  AUTHORIZATION postgres";
            Database.ExecuteNonQuery(script);
        }
        public override void Revert()
        {
            var script = $@"DROP SCHEMA tasksite
AUTHORIZATION postgres";
            Database.ExecuteNonQuery(script);
        }
    }
}
