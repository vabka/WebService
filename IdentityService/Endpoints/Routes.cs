namespace IdentityService.Endpoints;

public static class Routes
{
    public const string Root = "";

    public static class Api
    {
        public const string ApiPath = $"{Root}/api";

        public static class V1
        {
            public const string V1Path = $"{ApiPath}/v1";

            public static class Clients
            {
                public const string ClientsPath = $"{V1Path}/clients";

                public const string GetAll = ClientsPath;
                public const string GetById = $"{ClientsPath}/{{id}}";
                public const string CreateNew = ClientsPath;
                public const string DeleteById = $"{ClientsPath}/{{id}}";
            }
        }
    }
}