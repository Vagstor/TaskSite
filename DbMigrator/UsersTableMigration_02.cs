using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(2)]
    public class UsersTableMigration_02 : Migration
    {
        public override void Apply()
        {
            var script = $@"
CREATE TABLE tasksite.users
(
  id uuid NOT NULL,
  email character varying,
  login character varying,
  credentials character varying,
  password character varying,
  favfood character varying,
  pet character varying,
  age varying,
  CONSTRAINT users_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tasksite.users
  OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }
    }
}
