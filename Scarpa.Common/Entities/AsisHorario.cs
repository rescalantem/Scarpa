using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisHorario
    {
        public AsisHorario()
        {
            AsisRoles = new HashSet<AsisRoles>();
        }

        public int HorId { get; set; }
        public string HorDescripcion { get; set; }
        public byte HorRetardo { get; set; }
        public TimeSpan? HorLUnoEntrada { get; set; }
        public decimal HorLUnoHoras { get; set; }
        public TimeSpan? HorLDosEntrada { get; set; }
        public decimal HorLDosHoras { get; set; }
        public TimeSpan? HorLTresEntrada { get; set; }
        public decimal HorLTresHoras { get; set; }
        public TimeSpan? HorMUnoEntrada { get; set; }
        public decimal HorMUnoHoras { get; set; }
        public TimeSpan? HorMDosEntrada { get; set; }
        public decimal HorMDosHoras { get; set; }
        public TimeSpan? HorMTresEntrada { get; set; }
        public decimal HorMTresHoras { get; set; }
        public TimeSpan? HorEUnoEntrada { get; set; }
        public decimal HorEUnoHoras { get; set; }
        public TimeSpan? HorEDosEntrada { get; set; }
        public decimal HorEDosHoras { get; set; }
        public TimeSpan? HorETresEntrada { get; set; }
        public decimal HorETresHoras { get; set; }
        public TimeSpan? HorJUnoEntrada { get; set; }
        public decimal HorJUnoHoras { get; set; }
        public TimeSpan? HorJDosEntrada { get; set; }
        public decimal HorJDosHoras { get; set; }
        public TimeSpan? HorJTresEntrada { get; set; }
        public decimal HorJTresHoras { get; set; }
        public TimeSpan? HorVUnoEntrada { get; set; }
        public decimal HorVUnoHoras { get; set; }
        public TimeSpan? HorVDosEntrada { get; set; }
        public decimal HorVDosHoras { get; set; }
        public TimeSpan? HorVTresEntrada { get; set; }
        public decimal HorVTresHoras { get; set; }
        public TimeSpan? HorSUnoEntrada { get; set; }
        public decimal HorSUnoHoras { get; set; }
        public TimeSpan? HorSDosEntrada { get; set; }
        public decimal HorSDosHoras { get; set; }
        public TimeSpan? HorSTresEntrada { get; set; }
        public decimal HorSTresHoras { get; set; }
        public TimeSpan? HorDUnoEntrada { get; set; }
        public decimal HorDUnoHoras { get; set; }
        public TimeSpan? HorDDosEntrada { get; set; }
        public decimal HorDDosHoras { get; set; }
        public TimeSpan? HorDTresEntrada { get; set; }
        public decimal HorDTresHoras { get; set; }
        public int? TieId { get; set; }

        public Tiendas Tie { get; set; }
        public ICollection<AsisRoles> AsisRoles { get; set; }
    }
}
