# Terms
### Resource Owner 
Entity that owns resource (data).
Typically - User

### Service (client)
Entity that want to access resource.
Typically - your frontend or third-party site.

### Resource server
Entity that provides resource.
Typically - your RESTApi

### Authorization server
Service that resource server trusts.
It is IdentityServie is.
It issues access tokens

### Access token
Special string that tells resource server that client is authorized to acces specific resources.

### Refresh Token
- Used only to issue new access token.
- Does not sent to resource server
- You can issue new access token with short lifetime / narrowed scope


### Authorization grant
> authorization code, implicit, resource owner password
credentials, and client credentials -- as well as an extensibility
mechanism for defining additional types.

TODO

### Implicit flow
- Used in browsers. Implemented in js (on frontend)

TODO

### Resource Owner Password Credentials
- Client have limited time access to credentials (username & password). It is bad
- Easy
- Long-living access-token or refresh-token
- Credentials should not be stored
- Can be used when authorization server trusts client
- Credentials exchanged to access & refresh tokens pair

### Client Credentials
Client - Authorization server authentication method is not defined.


# Endpoints
### Authorization endpoint
Interaction with resource owner
MUST support GET
MAY support POST
authorization code grant
type and implicit grant type flows

### Token endpoint
TODO
### Redirection edpoint
TODO
