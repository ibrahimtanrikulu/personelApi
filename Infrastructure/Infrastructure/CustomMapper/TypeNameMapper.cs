namespace Infrastructure.CustomMapper
{
    public static class TypeNameMapper
    {
        public static TResult ConversionMapper<T,TResult>(T model) where TResult : class,new()
        {
            TResult result = new TResult();
            var properties = typeof(T).GetProperties().ToList();
            foreach (var property in properties)
            {
                var value = typeof(TResult).GetProperty(property.Name);
                value.SetValue(result, property.GetValue(model));
            }

            return result;
        }
    }
}
