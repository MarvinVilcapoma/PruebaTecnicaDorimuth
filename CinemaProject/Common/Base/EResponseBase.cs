using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Base
{
    public class EResponseBase<TEntity> : ICloneable where TEntity : class, new()
    {
        public int? Code { get; set; }
        public string? Message { get; set; }
        public string? MessageEN { get; set; }
        public bool IsResultList { get; set; } = false;
        public IEnumerable<TEntity>? listado { get; set; }
        public string? dato { get; set; }
        //public Exception TechnicalErrors { get; set; }
        public List<string>? FunctionalErrors { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("Response[Code: {0}, Message: {1},  listado: {2}]", Code, Message, listado);
        }

    }
}
