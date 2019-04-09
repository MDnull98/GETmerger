namespace GETmerger.Core.Models
{
    public class GenericResponse
    {
        public GenericResponse()
        {
        }

        public GenericResponse(object result)
        {
            Result = result;
        }

        public object Result { get; set; } = null;
    }

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
