using System;

namespace Pam.Dao.Entites
{
    // classe d'exception
    public class PamException : Exception
    {
        // le code de l'erreur
        public int Code { get; set; }
        // constructeurs
        public PamException()
        {
        }
        public PamException(int Code)
            : base()
        {
            this.Code = Code;
        }
        public PamException(string message, int Code)
            : base(message)
        {
            this.Code = Code;
        }
        public PamException(string message, Exception ex, int Code)
            : base(message, ex)
        {
            this.Code = Code;
        }
    }
}
