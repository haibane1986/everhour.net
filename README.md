[![Build Status](https://travis-ci.org/haibane1986/everhour.net.svg?branch=master)](https://travis-ci.org/haibane1986/everhour.net)

# Everhour.Net
[Everhour API](https://everhour.docs.apiary.io/) wrapper in .NET Core.

## Installation

This library is hosted as a [nuget package](https://www.nuget.org/packages/Everhour.Net/).

To install Everhour.Net, run the following command.

```
dotnet add package Everhour.Net
```

## Usage

Create a client object:

```
var client = new EverhourClient("API_TOKEN_HERE");
```

Everhour API end points are converted to PascalCase.   
So `api.everhour.com/users/me` becomes

```
var res = await client.MeAsync();
```

# Notes
It is based on the [Everhour API Docs](https://everhour.docs.apiary.io/#).  
However, although it is not listed in the [Everhour API Docs](https://everhour.docs.apiary.io/#), it refers to the key included in the actual request and response.