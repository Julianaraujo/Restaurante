using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restaurante.Models
{
    public class Contexto:DbContext
    {
        public Contexto() : base(nameOrConnectionString: "StringConexao") { }

        public DbSet<Cardapio> Cardapio { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Consumo> Consumo { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<CardapioConsumo> CardapioConsumo { get; set; }
    }
}