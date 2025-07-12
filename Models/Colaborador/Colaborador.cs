namespace TalentUP.Models.Colaborador
{
    public class Colaborador
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        //Pontuação començando sempre com 0
        public double Pontuacao { get; set; } = 0;
    }
}