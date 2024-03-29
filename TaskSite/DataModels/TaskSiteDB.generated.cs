﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : tasksite
	/// Data Source    : tcp://localhost:5432
	/// Server Version : 13.2
	/// </summary>
	public partial class MainDb : LinqToDB.Data.DataConnection
	{
		public ITable<User> Users { get { return this.GetTable<User>(); } }

		partial void InitMappingSchema()
		{
		}

		public MainDb()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public MainDb(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="tasksite", Name="users")]
	public partial class User
	{
		[Column("id"),          PrimaryKey,  NotNull] public Guid   Id          { get; set; } // uuid
		[Column("email"),          Nullable         ] public string Email       { get; set; } // character varying
		[Column("login"),          Nullable         ] public string Login       { get; set; } // character varying
		[Column("credentials"),    Nullable         ] public string Credentials { get; set; } // character varying
		[Column("password"),       Nullable         ] public string Password    { get; set; } // character varying
		[Column("favfood"),        Nullable         ] public string Favfood     { get; set; } // character varying
		[Column("pet"),            Nullable         ] public string Pet         { get; set; } // character varying
		[Column("age"),            Nullable         ] public string Age         { get; set; } // integer
	}

	public static partial class TableExtensions
	{
		public static User Find(this ITable<User> table, Guid Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}

#pragma warning restore 1591
