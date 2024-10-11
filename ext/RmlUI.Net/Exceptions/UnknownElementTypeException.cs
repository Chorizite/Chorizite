namespace RmlUiNet.Exceptions
{
    public class UnknownElementTypeException : RmlExceptionBase
    {
        public string ElementType { get; }

        public UnknownElementTypeException(string elementType)
        {
            ElementType = elementType;
        }
    }
}
