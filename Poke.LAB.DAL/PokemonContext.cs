using Microsoft.EntityFrameworkCore;
using Poke.LAB.DAL.Models.Pokemon;

namespace Poke.LAB.DAL
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base (options) { }

        //Propiedades del Context (Para usar en proyecto)
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonSprites> PokemonSprites { get; set; }
        public DbSet<Nature> Nature { get; set; }
        public DbSet<Ability> Ability { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Pokemon
            modelBuilder.Entity<Pokemon>()
                .HasKey(k => k.PokemonID);
            modelBuilder.Entity<Pokemon>()
                .HasIndex(k => k.PokeAPI_ID);
            //PokemonSprites
            modelBuilder.Entity<PokemonSprites>()
                .HasKey(k => k.PokeSpriteID);
            modelBuilder.Entity<PokemonSprites>()
                .HasOne(p => p.Pokemon)
                .WithOne(ps => ps.Sprites)
                .HasForeignKey<PokemonSprites>(fk => fk.PokemonID);


            //Naturaleza
            modelBuilder.Entity<Nature>()
                .HasKey(k => k.NatureID);
            modelBuilder.Entity<Nature>()
                .HasIndex(k => k.PokeAPI_ID);

            //Habilidad
            modelBuilder.Entity<Ability>()
                .HasKey(k => k.AbilityID);
            modelBuilder.Entity<Ability>()
                .HasIndex(k => k.PokeAPI_ID);
        }
    }
    /*
    public class Persona
    {
        public Persona(string nombre, string sex)
        {
            Nombre = nombre;
            Sex = sex;
        }

        public string Nombre { get; set; }
        public string Sex { get; set; }
    }

    public class Monje : Persona
    {
        public Monje(string iglesia, string nombre, string Sex) : base (nombre, Sex)
        {
            Iglesia = iglesia;
        }

        public string Iglesia { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            Persona weon = new Persona("Jesus", "H");
            Monje weonMonje = new Monje("Villas", "Arturo", "H");
        }
    }
    */
}
