using System.Collections.Generic;

namespace GETmerger.Core.Models
{
    public class GenericResponse<T>
    {
        public GenericResponse()
        {
            
        }

        public GenericResponse(T model)
        {
            Result = model;
        }
        public T Result { get; set; }
    }
}
