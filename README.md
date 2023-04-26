# .Net Core RateLimiting Example

## Description

This project is a .NET Core application that demonstrates how to implement rate limiting for RESTful APIs using the **AspNetCoreRateLimit** library.

## Prerequisites

To run this project, you will need the following:

- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download/dotnet-core/6.0)
- An IDE of your choice (e.g. Visual Studio, Visual Studio Code)

## Running the Project

To run the project, follow these steps:

1. Clone the repository to your local machine.

```bash
git clone https://github.com/BerkayMehmetSert/netCore.RateLimiting.git
```

2. Open the project in your IDE of choice.

3. Run the project.

```bash
dotnet run
```

## Configuring Rate Limiting

The rate limiting settings for the API are defined in the **appsettings.json** file. You can change the settings to suit your needs. The settings include:

- **EnableEndpointRateLimiting**: Whether or not to enable rate limiting for endpoints.
- **StackBlockedRequests**: Whether or not to stack blocked requests and process them later.
- **RealIpHeader**: The header name that contains the client's real IP address.
- **ClientIdHeader**: The header name that contains the client ID.
- **HttpStatusCode**: The HTTP status code to return when a client is blocked.
- **GeneralRules**: A list of rules that apply to all endpoints. Each rule has the following properties:
	- **Endpoint**: The endpoint pattern (e.g. /api/customers/*).
	- **Period**: The time period for the rule (e.g. 1m for 1 minute).
	- **Limit**: The maximum number of requests allowed during the period.

## Usage

The API has the following endpoints:

- **POST** `/api/customers`: Creates a new customer.
- **PUT** `/api/customers/{id}`: Updates an existing customer.
- **DELETE** `/api/customers/{id}`: Deletes an existing customer.
- **GET** `/api/customers/{id}`: Retrieves an existing customer by ID.
- **GET** `/api/customers`: Retrieves a list of all customers.

Each endpoint is rate-limited according to the rules defined in the **appsettings.json** file.
