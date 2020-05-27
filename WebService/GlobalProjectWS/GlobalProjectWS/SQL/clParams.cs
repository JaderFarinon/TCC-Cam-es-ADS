using System.Data;

namespace GlobalProjectWS
{
    public class classParams
    {
        public string Parametro;
        public object Valor;
        public ParameterDirection InOut;
        public SqlDbType inoutDataType;

        public classParams(string parametro, object valor)
        {
            this.Parametro = parametro;
            this.Valor = valor;
            this.InOut = ParameterDirection.Input;
        }
        public classParams(string parametro, object valor, ParameterDirection inout)
        {
            this.Parametro = parametro;
            this.Valor = valor;
            this.InOut = inout;
        }

        public classParams(string parametro, object valor, ParameterDirection inout, SqlDbType inoutDataType)
        {
            this.Parametro = parametro;
            this.Valor = valor;
            this.InOut = inout;
            this.inoutDataType = inoutDataType;
        }

    }
}
