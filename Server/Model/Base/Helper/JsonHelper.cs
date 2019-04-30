namespace Model.Base.Helper
{
    public static class JsonHelper
    {
        public static T ToObject<T>(string str)
        {
            return MongoHelper.FromJson<T>(str);
        }

        public static string ToJson(this object obj)
        {
            return MongoHelper.ToJson(obj);
        }
    }
}
