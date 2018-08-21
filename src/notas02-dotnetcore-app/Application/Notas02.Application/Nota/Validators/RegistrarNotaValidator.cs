namespace Notas02.Application.Nota.Validators
{
    public class RegistrarNotaValidator : NotaValidator
    {
        public RegistrarNotaValidator()
        {
            ValidaReferencia();
            ValidaValorUnitario();
            ValidaQuantidade();
        }
    }
}