namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
           if(Suite != null && Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("Reserva não realizada por excedente de hospedes!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            //return Hospedes?.Count ?? 0; (Recurso do C# abreviado para condiconal abaixo)
            //?. Se o objeto não for null, retorna valor. Se for nulo, retorna null(e não lança erro)
            if (Hospedes != null)
{
    return Hospedes.Count;
}
else
{
    return 0;
}
}
            

        public decimal CalcularValorDiaria()
        {
            //  Retorna o valor da diária
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            
            if (DiasReservados >=10)
            {
                //valorTotal *= 0.9m; (ou seja, apenas 90% do valor total)
                //Equivale a:
                
                valorTotal = valorTotal * 0.9m; //o "m" indica tipo decimal (obrigatório para valor monetário em C#)
            }

            return valorTotal;
        }
    }
}