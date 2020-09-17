using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class AlimentosServicio
    {
        private static List<Alimento> alimentos { get; set; }

        public AlimentosServicio()
        {
            if (alimentos == null)
            {
                alimentos = new List<Alimento>()
                {
                    new Alimento(){ Id=1, Nombre="A", Peso=50 },

                };
            }
        }

        public List<Alimento> ListarAlimentos()
        {

            return alimentos;
        }

        public void CrearAlimento(Alimento a)
        {
            int MaxID = 0;
            if (alimentos.Count > 0) {
            MaxID = alimentos.Max(b => b.Id);
            }
            MaxID++;

            a.Id = MaxID;
            alimentos.Add(a);
        }

        public void Editar(Alimento a)
        {
            Alimento alimentoEncontrado = this.BuscarAlimentoPorId(a.Id);
            alimentoEncontrado.Nombre = a.Nombre;
            alimentoEncontrado.Peso = a.Peso;
        }

        public Alimento BuscarAlimentoPorId(int id)
        {
            Alimento a = null;
            foreach (Alimento aux in alimentos)
            {
                if (aux.Id == id)
                {
                    a = aux;
                }
            }

            return a;
        }

        public void Eliminar(int id)
        {
            Alimento a = this.BuscarAlimentoPorId(id);
            alimentos.Remove(a);
        }

    }
}
