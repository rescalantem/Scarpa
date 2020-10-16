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
        public byte HorLUnoHoras { get; set; }
        public TimeSpan? HorLDosEntrada { get; set; }
        public byte HorLDosHoras { get; set; }
        public TimeSpan? HorLTresEntrada { get; set; }
        public byte HorLTresHoras { get; set; }
        public TimeSpan? HorMUnoEntrada { get; set; }
        public byte HorMUnoHoras { get; set; }
        public TimeSpan? HorMDosEntrada { get; set; }
        public byte HorMDosHoras { get; set; }
        public TimeSpan? HorMTresEntrada { get; set; }
        public byte HorMTresHoras { get; set; }
        public TimeSpan? HorEUnoEntrada { get; set; }
        public byte HorEUnoHoras { get; set; }
        public TimeSpan? HorEDosEntrada { get; set; }
        public byte HorEDosHoras { get; set; }
        public TimeSpan? HorETresEntrada { get; set; }
        public byte HorETresHoras { get; set; }
        public TimeSpan? HorJUnoEntrada { get; set; }
        public byte HorJUnoHoras { get; set; }
        public TimeSpan? HorJDosEntrada { get; set; }
        public byte HorJDosHoras { get; set; }
        public TimeSpan? HorJTresEntrada { get; set; }
        public byte HorJTresHoras { get; set; }
        public TimeSpan? HorVUnoEntrada { get; set; }
        public byte HorVUnoHoras { get; set; }
        public TimeSpan? HorVDosEntrada { get; set; }
        public byte HorVDosHoras { get; set; }
        public TimeSpan? HorVTresEntrada { get; set; }
        public byte HorVTresHoras { get; set; }
        public TimeSpan? HorSUnoEntrada { get; set; }
        public byte HorSUnoHoras { get; set; }
        public TimeSpan? HorSDosEntrada { get; set; }
        public byte HorSDosHoras { get; set; }
        public TimeSpan? HorSTresEntrada { get; set; }
        public byte HorSTresHoras { get; set; }
        public TimeSpan? HorDUnoEntrada { get; set; }
        public byte HorDUnoHoras { get; set; }
        public TimeSpan? HorDDosEntrada { get; set; }
        public byte HorDDosHoras { get; set; }
        public TimeSpan? HorDTresEntrada { get; set; }
        public byte HorDTresHoras { get; set; }
        public int? TieId { get; set; }

        public Tiendas Tie { get; set; }
        public ICollection<AsisRoles> AsisRoles { get; set; }
    }
}
