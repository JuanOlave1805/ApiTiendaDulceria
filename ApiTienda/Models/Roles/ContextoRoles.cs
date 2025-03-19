﻿using Microsoft.EntityFrameworkCore;

namespace ApiTiendaDulceria.Models.Roles
{
    /// <summary>
    /// Contexto de base de datos para la entidad Tipo Identificacion.
    /// Gestiona la conexión a la base de datos y las operaciones con la tabla Tipo Identificacion.
    /// </summary>
    public class ContextoRoles : DbContext
    {
        /// <summary>
        /// Constructor del contexto que recibe opciones de configuración.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto.</param>
        public ContextoRoles(DbContextOptions<ContextoRoles> options) : base(options) { }

        /// <summary>
        /// Conjunto de datos que representa la tabla Tipo documentos en la base de datos.
        /// </summary>
        public DbSet<Roles> Roles { get; set; }
    }
}
