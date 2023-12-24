# Hotel Management API

## Översikt

Detta projekt är en API för hantering av hotell, rum och kunder. Det erbjuder CRUD-operationer (Create, Read, Update, Delete) för dessa entiteter genom olika HTTP-metoder i en ASP.NET Core-applikation.

### Entiteter

- **Customer**: Representerar en kund med en unik ID och namn. En kund kan vara associerad med flera rum.
- **Hotel**: Representerar ett hotell med en unik ID och namn. Ett hotell kan ha flera rum.
- **Room**: Representerar ett rum med en unik ID, namn och en koppling till ett hotell (kan vara null). Ett rum kan ha flera kunder.

### Kontrollers

- **CustomerController**: Hanterar kunder och deras associerade rum. Tillhandahåller CRUD-operationer för kunder.
- **HotelController**: Hanterar hotell och deras rum. Ger CRUD-operationer för hotell.
- **RoomController**: Hanterar rum och deras detaljer. Ger CRUD-operationer för rum.

### Data Access Layer

- **Context**: En DbContext-klass som är ansvarig för att interagera med databasen. Den innehåller DbSet-egenskaper för Customer, Hotel och Room, och är konfigurerad att använda en SQL Server-databas.

### Dependency Injection

- **AddDbContext**: Registrerar DbContext i tjänstekontainern för att möjliggöra databasåtkomst för applikationen.
- **AddControllers**: Registrerar controllers i applikationen för att hantera begäranden.

### Övrigt

- Användningen av Swagger och OpenAPI för att dokumentera API:et och generera interaktiv dokumentation.

Projektet implementerar en strukturerad och standardiserad RESTful API-arkitektur för att hantera olika aspekter av hotellhantering, inklusive kunder, rum och hotell.

