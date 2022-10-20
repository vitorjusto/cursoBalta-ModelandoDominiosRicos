namespace PaymentContext.Domain.ValueObjects
{
    public class CPF
    {
        public string Value { get; set; }

        public CPF(string value)
        {
            Value = value;
        }

        public CPF()
        {
        }

        //transforma string em cpf
        public static implicit operator CPF(string cpf)
            => new CPF(cpf);

        //transforma cpf em string
        public static implicit operator string(CPF cpf)
            => cpf.Value;
    }
}
