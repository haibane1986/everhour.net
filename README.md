[![Build Status](https://travis-ci.org/haibane1986/everhour.net.svg?branch=master)](https://travis-ci.org/haibane1986/everhour.net)

# Everhour.Net
[Everhour API](https://everhour.docs.apiary.io/) wrapper in .Net.

## Usage

Create a client object:

```
var client = new EverhourClient("hoge-fuga-piyo-moge-noge");
```

Everhour API end points are converted to PascalCase. So `api.everhour.com/users/me` becomes

    var res = client.MeAsync();